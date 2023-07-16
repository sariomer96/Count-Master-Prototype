using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerUnitController : CharacterUnit
{
    #region Unity Methods

    private PlayerMovement playerMovement;
 
    private void OnEnable()
    {
        
        destination = transform.parent;

        

         playerMovement = transform.GetComponentInParent<PlayerMovement>();
     
        if (playerMovement)
        {
            playerMovement.Count++;
            playerMovement.characterUnits.Add(this);
        }
           
       

    }


  
    private void OnDisable()
    { 
        /*if (playerMovement)
        {
            
            print(playerMovement);
             playerMovement.RemoveUnit(this);
     
           playerMovement.Count--;
            if (playerMovement.characterUnits.Count==0)
            {
                print("ll");
                playerMovement.FightStatus();
             
            }
        }*/
            
    }

    void KillUnit()
    {
        if (playerMovement)
        {
            print(playerMovement);
            playerMovement.RemoveUnit(this);
     
            playerMovement.Count--;
            if (playerMovement.characterUnits.Count==0)
            {
              
                playerMovement.FightStatus();
             
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("trap"))
        {

            StartCoroutine(nameof(Fall));
        }

        if (other.CompareTag("enemyUnit"))
        {
            CharacterUnit enemy=other.GetComponentInParent<CharacterUnit>();
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
        _rigidbody.constraints = RigidbodyConstraints.None;
        _rigidbody.useGravity = true;
        playerMovement.RemoveUnit(this);
        playerMovement.FailCheck();
        yield return new WaitForSeconds(1f);
        
        
        Character character = transform.GetComponentInParent<Character>();
        ObjectPool.Instance.ReturnToPool(this,character.characterType);
      
    }

    #endregion


    protected override void CheckFightStatus()
    {
         print("gameover");
    }
}
