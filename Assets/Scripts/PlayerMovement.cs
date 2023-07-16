using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
   public float clampX = 2;
  
   
    public Transform centerPosition;
    public void Move()
    {
 
        _rigidbody.velocity = new Vector3(_pos.x*_swerveSpeed, 0, verticalSpeed);
    
    }

    
    public void StopMove()
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
        
        Vector3 pos = _rigidbody.position;
        pos.x = Mathf.Clamp(pos.x, -clampX,clampX);

        transform.position = pos;
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
    /*public void RemoveUnit(CharacterUnit unit)
    {
         
         Count--;
        characterUnits.Remove(unit);
    
       OnCountChanged?.Invoke();
    }

    public void AddUnit(CharacterUnit unit)
    {
        Count++;
        characterUnits.Add(unit);
       
        OnCountChanged?.Invoke();
    }*/



    public void FailCheck()
     {
        
        if (characterUnits.Count==0)
        {
            UiManager.Instance.Retry();
            StopMove();
        } 
    }

    /*private void OnEnable()
    { 
        OnCountChanged += SetCountText;
         
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemyArea"))
        {
            _enemy = other.GetComponent<Enemy>();
            StopMove();

           Transform hitCenter= GetCenterTransform(_enemy.transform.position);
            SetTargetNavAgentAllUnit(hitCenter);
            _enemy.SetTargetNavAgentAllUnit(hitCenter);

            SetNavAgentSpeed(navAgentMaxSpeed);
        }

        if (other.CompareTag("Finish"))
        {
            StopNavmesh();
             StopMove();
             countTxt.enabled = false;
            _btsf.Build();
           
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
         
       _btsf = GetComponent<Btsf>();
 

    }

    /*
    private void OnDestroy()
    {
        OnCountChanged -= SetCountText;
    }
    */


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
