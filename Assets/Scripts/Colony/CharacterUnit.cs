using System;
using UnityEngine;
using UnityEngine.AI;

namespace Colony
{
    public abstract class CharacterUnit : MonoBehaviour
    {
        private CrowdSpawner spawner;
    
        protected Rigidbody rigidBody;
        protected Colony _colony;
        protected PlayerColonyController playerColony;
    
        public NavMeshAgent agent;
        public Transform destination;
        [SerializeField] private float stoppingDistance = 0.3f;
        private void Start()
        {
            agent.stoppingDistance =stoppingDistance;
        }

        void ResetUnit()
        {
            if (agent)
                agent.speed = playerColony.navAgentSpeed;

            rigidBody.constraints = RigidbodyConstraints.FreezeAll;
            rigidBody.useGravity = false;
            agent.enabled = true;
        }
        private void OnDisable()
        {

            ResetUnit();
        }

        private void Awake()
        {
            agent =GetComponent<NavMeshAgent>();
            rigidBody = GetComponent<Rigidbody>();
            playerColony=PlayerColonyController.Instance;
        }

        private void Update()
        {
            if (agent.enabled) 
                agent.SetDestination(destination.localPosition);
   
        }

    }
}
