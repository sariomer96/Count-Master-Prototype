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
    
    public void Move()
    {
 
        _rigidbody.velocity = new Vector3(_pos.x*_swerveSpeed, 0, verticalSpeed);

    }

    
    void StopMove()
    {
        
        verticalSpeed = 0;
        _swerveSpeed = 0;
    }

    void StartMove()
    {
        verticalSpeed = 2f;
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
      
    }

    public override void FightStatus()
    {
        //SetTargetNavAgentAllUnit(transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemyArea"))
        {
            _enemy = other.GetComponent<Enemy>();
            StopMove();
            SetTargetNavAgentAllUnit(other.transform);

        }
    }

    private void FixedUpdate()
    {
        Move();
    }

 
}
