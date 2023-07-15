using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class CharacterUnit : MonoBehaviour
{
    private CrowdSpawner spawner;
    [SerializeField] public Transform destination;
    protected Rigidbody _rigidbody;

    protected abstract void CheckFightStatus();
    protected Character _character;
    
    public NavMeshAgent agent;
    // Start is called before the first frame update
   
   

    private void Start()
    {
        
        agent =GetComponent<NavMeshAgent>();
        _rigidbody = GetComponent<Rigidbody>();
    }
  


    private void Update()
    {
        if (agent.enabled) agent.SetDestination(destination.localPosition);
   
    }

}
