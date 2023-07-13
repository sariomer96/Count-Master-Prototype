using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerUnitController : CharacterUnit
{
    private Rigidbody _rigidbody;
    #region Private Fields

    [SerializeField] private Transform destination;
   
    
    private NavMeshAgent agent;
    private bool isDead = false;

    #endregion

    #region Properties

    public bool IsDead
    {
        get => isDead;
        set => isDead = value;
    }

    #endregion

    #region Unity Methods

    private void Start()
    {
        
        agent = this.GetComponent<NavMeshAgent>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        destination = transform.parent;
    }

    

    private void Update()
    {
        if (agent.enabled) agent.SetDestination(destination.localPosition);
    }
 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("trap"))
        {

            StartCoroutine(nameof(Fall));
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
 
 
}
