using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected float _moveSpeed = 2f;
    public List<CharacterUnit> characterUnits = new List<CharacterUnit>();


   
   [SerializeField] public PoolTypes.CharacterTypes characterType;




   public virtual void FightStatus()
   {
       
   }

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
