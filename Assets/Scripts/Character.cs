using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected float _moveSpeed = 2f;
    public List<CharacterUnit> characterUnits = new List<CharacterUnit>();
    public int Count
    {
        get
        {
            return count;
        }
        set
        {
            count = value;
            FightStatus();
            
        }
    }

    private int count=0;
   
   [SerializeField] public PoolTypes.CharacterTypes characterType;




   public abstract void FightStatus();
    
  public void SetTargetNavAgentAllUnit(Transform target)
   {
       for (int i = 0; i < characterUnits.Count; i++)
       {
           characterUnits[i].destination = target;
       }
   }
   
   /*private void OnTriggerEnter(Collider other)
   {
       if (other.CompareTag("Player"))
       {
           foreach (var VARIABLE in characterUnits)
           {
               VARIABLE.destination = other.transform;
           }
       }
   }*/
}
