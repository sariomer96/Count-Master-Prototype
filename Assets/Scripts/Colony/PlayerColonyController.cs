using Managers;
using ObjectPool;
using Swerve;
using Tower;
using UnityEngine;

namespace Colony
{
    public class PlayerColonyController : Colony, IMovable
    {

        private SwerveInputSystem _swerveInputSystem;
        private Vector3 _pos;
        private EnemyColony _enemy;
        [SerializeField] private float _forwardSpeed = 2f;
        [SerializeField] private float _swerveSpeed = 10f;
        private Rigidbody _rigidbody;
        private MakeTower _makeTower;
        private float _tempForwardSpeed;
        private float _tempSwerveSpeed;
    
        public bool isMove = true; 
        public static PlayerColonyController Instance { get; set; }
        public float clampX = 2;
        public Transform centerPosition;
     
  
        private void Start()
        {
            
        
            SetTempSpeeds();
        }

        public void AddUnit(int count)
        {
            for (int i = 0; i < count; i++)
                ObjectPool.ObjectPool.Instance.GetPooledObject((int)PoolTypes.CharacterTypes.MainPlayer,transform);
        }
   
        public void Move()
        {
            _rigidbody.velocity = new Vector3(_pos.x*_swerveSpeed, 0, _forwardSpeed);
        }

    
        public void StopMove()
        {
        
            _forwardSpeed = 0;
            _swerveSpeed = 0;
       
        }

        public void StartMove()
        {
        
            _forwardSpeed =_tempForwardSpeed;
            _swerveSpeed = _tempSwerveSpeed;
       
        }

        private void Update()
        {
            _pos = _swerveInputSystem.GetDirection();
        
            Vector3 pos = _rigidbody.position;
            pos.x = Mathf.Clamp(pos.x, -clampX,clampX);

            transform.position = pos;
        }


        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            
            _makeTower = GetComponent<MakeTower>();
            _rigidbody = GetComponent<Rigidbody>();
            _swerveInputSystem = GetComponent<SwerveInputSystem>();
            
          
        }
  
        public void FailCheck()
        {
        
            if (characterUnits.Count==0)
            {
                _rigidbody.velocity=Vector3.zero;
                isMove = false;
                UiManager.Instance.Retry();
                StopMove();
            } 
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("enemyArea"))
            {
                StopMove();
                ChangeTargetUnits(other.transform);
                SetNavAgentSpeed(navAgentMaxSpeed);
            }

            if (other.CompareTag("Finish"))
            {
                StopNavmesh();
                StopMove();
                countTxt.enabled = false;
                _makeTower.Build();
            } 
        }

        void ChangeTargetUnits(Transform hitEnemy)
        {
            _enemy = hitEnemy.GetComponent<EnemyColony>();
            Transform hitCenter= GetCenterTransform(_enemy.transform.position);
            SetTargetNavAgentAllUnit(hitCenter);
            _enemy.SetTargetNavAgentAllUnit(hitCenter);
          
        }
        
        void StopNavmesh()
        {
            for (int i = 0; i < characterUnits.Count; i++)
                characterUnits[i].agent.enabled = false;
        
        }
        void SetTempSpeeds()
        {
            _tempForwardSpeed = _forwardSpeed;
            _tempSwerveSpeed = _swerveSpeed;
        }

        Transform GetCenterTransform(Vector3 enemyPosition)
        {
            Vector3 centerPos = (transform.position + enemyPosition) / 2;

            centerPosition.position = centerPos;
            return centerPosition;
        }
        private void FixedUpdate()
        {
            if (isMove)
                Move(); 
        }

 
    }
}
