using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class CharacterUnit : MonoBehaviour
{
    private CrowdSpawner spawner;
    
    protected Rigidbody rigidBody;
    protected Colony _colony;
    protected PlayerColonyController playerColony;
    
    public NavMeshAgent agent;
    public Transform destination;

    private void Start()
    {
        agent =GetComponent<NavMeshAgent>();
        rigidBody = GetComponent<Rigidbody>();
        
    }

    private void Awake()
    {
        playerColony=PlayerColonyController.Instance;
    }

    private void Update()
    {
        if (agent.enabled) 
            agent.SetDestination(destination.localPosition);
   
    }

}
