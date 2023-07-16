using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private PlayerMovement _playerMovement;
    [SerializeField] public Transform hitPoint;
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerMovement = other.GetComponent<PlayerMovement>();
           
        }
        
        
    }

    public override void FightStatus()
    {
        
        if (Count==0&&_playerMovement)
        {
             
            _playerMovement.SetTargetNavAgentAllUnit(_playerMovement.transform);
    
            _playerMovement.StartMove();
        }
    }
}
