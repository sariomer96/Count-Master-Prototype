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
            _character.AddUnit(this);
        
        }
         
       

    }

 
    private void OnDisable()
    { 
        if (_character)
        {
       
            _character.RemoveUnit(this);
          //  _character.Count--;
         
        }
            
    }
    
 
    protected override void CheckFightStatus()
    {
         
    }
}
