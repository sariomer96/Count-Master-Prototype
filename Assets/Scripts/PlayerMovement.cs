using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Character, IMovable
{

    private SwerveInputSystem _swerveInputSystem;
  
    private Vector3 _pos;
    public float verticalSpeed = 2f;
    private float mouseX = 0f;
    private Enemy _enemy;
    [SerializeField] private float _swerveSpeed = 10f;
    private Rigidbody _rigidbody;
    
    private BuildTower _buildTower;
    private Btsf _btsf;
   public static PlayerMovement Instance { get; set; }
    public Transform centerPosition;
    public void Move()
    {
 
        _rigidbody.velocity = new Vector3(_pos.x*_swerveSpeed, 0, verticalSpeed);

    }

    
    void StopMove()
    {
        
        verticalSpeed = 0;
        _swerveSpeed = 0;
        
    }

    public void StartMove()
    {
        verticalSpeed = 7f;
        _swerveSpeed = 10f;
    }

    private void Update()
    {
        _pos = _swerveInputSystem.GetDirection();
         
    }


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _swerveInputSystem = GetComponent<SwerveInputSystem>();
        if (Instance == null)
            Instance = this;
    }

    public override void FightStatus()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemyArea"))
        {
            _enemy = other.GetComponent<Enemy>();
            StopMove();

           Transform hitCenter= GetCenterTransform(_enemy.transform.position);
            SetTargetNavAgentAllUnit(hitCenter);
            _enemy.SetTargetNavAgentAllUnit(hitCenter);

        }

        if (other.CompareTag("Finish"))
        {
            StopNavmesh();
             StopMove();
        //            _buildTower.Build();
            _btsf.Build();;
            print("trig");
            
        }
    }

    void StopNavmesh()
    {
        for (int i = 0; i < characterUnits.Count; i++)
        {
            characterUnits[i].agent.enabled = false;
        }
    }

    private void Start()
    {
        
       // _buildTower = GetComponent<BuildTower>();
       _btsf = GetComponent<Btsf>();
    }

    Transform GetCenterTransform(Vector3 enemyPosition)
    {
        Vector3 centerPos = (transform.position + enemyPosition) / 2;

        centerPosition.position = centerPos;
        return centerPosition;
    }
    private void FixedUpdate()
    {
       
            Move(); 
    }

 
}
