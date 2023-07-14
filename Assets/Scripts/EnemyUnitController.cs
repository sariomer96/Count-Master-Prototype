using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnitController : CharacterUnit
{
   
    private void OnEnable()
    {
        
        destination = transform.parent;

        _character = transform.GetComponentInParent<Character>();

        if (_character)
        {
            _character.characterUnits.Add(this);
            _character.Count++;
        }
         
       

    }

 
    private void OnDisable()
    { 
        if (_character)
        {
       
            _character.characterUnits.Remove(this);
            _character.Count--;
         
        }
            
    }
    
 
    protected override void CheckFightStatus()
    {
         
    }
}
