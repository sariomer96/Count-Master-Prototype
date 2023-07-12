using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected float _moveSpeed = 2f;
    [SerializeField] protected Rigidbody _rigidbody;

    
  
   [SerializeField] protected PoolTypes.CharacterTypes characterType;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
}
