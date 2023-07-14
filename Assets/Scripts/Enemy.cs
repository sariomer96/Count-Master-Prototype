using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private PlayerMovement _playerMovement;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerMovement = other.GetComponent<PlayerMovement>();
            SetTargetNavAgentAllUnit(other.transform);
        }
        
        
    }

    public override void FightStatus()
    {
         _playerMovement.SetTargetNavAgentAllUnit(_playerMovement.transform);
    }
}
