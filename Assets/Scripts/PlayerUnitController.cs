using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerUnitController : CharacterUnit
{
    #region Unity Methods


    
    
      
    private void OnEnable()
    {
        
        destination = transform.parent;

        _character = transform.GetComponentInParent<Character>();

        if (_character)
            _character.characterUnits.Add(this);
       

    }

 
    private void OnDisable()
    { 
        if (_character)
        {
            _character.characterUnits.Remove(this);
            if (_character.characterUnits.Count==0)
            {
                _character.FightStatus();
             
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
            other.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }

    IEnumerator Fall()
    {
        agent.enabled = false;
        _rigidbody.constraints = RigidbodyConstraints.None;
        _rigidbody.useGravity = true;
        
        yield return new WaitForSeconds(3.5f);
        
        Character character = transform.GetComponentInParent<Character>();
        ObjectPool.Instance.ReturnToPool(this,character.characterType);
    }

    #endregion


    protected override void CheckFightStatus()
    {
         print("gameover");
    }
}
