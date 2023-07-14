using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnitController : CharacterUnit
{
   
    
    
    private void OnDisable()
    {


        if (_character)
        {
            _character.characterUnits.Remove(this);
            if (_character.characterUnits.Count==0)
            {
                CheckFightStatus();
              
            }
        }
            
    }
    protected override void CheckFightStatus()
    {
         
    }
}
