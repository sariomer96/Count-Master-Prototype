using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerUnitController : CharacterUnit
{
    
 
    private void OnEnable()
    {
        destination = transform.parent;

        playerColony.AddUnit(this);
        
    }
    void KillUnit()
    {
         
       playerColony.RemoveUnit(this);
      
       if (playerColony.characterUnits.Count==0)
           playerColony.FailCheck();
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("trap"))
            StartCoroutine(nameof(Fall));
        

        if (other.CompareTag("enemyUnit"))
        {
            CharacterUnit enemy=other.GetComponent<CharacterUnit>();
            ObjectPool.Instance.ReturnToPool(this,PoolTypes.CharacterTypes.MainPlayer);
            ObjectPool.Instance.ReturnToPool(enemy,PoolTypes.CharacterTypes.Enemy);
            KillUnit();
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    IEnumerator Fall()
    {
  
        agent.enabled = false;
        rigidBody.constraints = RigidbodyConstraints.None;
        rigidBody.useGravity = true;
        
        playerColony.RemoveUnit(this);
        playerColony.FailCheck();
        
        yield return new WaitForSeconds(1f);
         
        Colony colony = transform.GetComponentInParent<Colony>();
        ObjectPool.Instance.ReturnToPool(this,colony.characterType);
      
    }
 
}
