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

    [SerializeField] private float _swerveSpeed = 10f;
    public void Move()
    {
 
        _rigidbody.velocity = new Vector3(_pos.x*_swerveSpeed, 0, verticalSpeed);

    }

 

    private void Update()
    {
        _pos = _swerveInputSystem.GetDirection();
         
    }


    private void Awake()
    {
        _swerveInputSystem = GetComponent<SwerveInputSystem>();
     
    }

  
    private void FixedUpdate()
    {
     
        Move();
    
      
    }
}
