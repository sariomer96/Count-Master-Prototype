using System;
using System.Collections.Generic;
using ObjectPool;
using TMPro;
using UnityEngine;

namespace Colony
{
    public abstract class Colony : MonoBehaviour
    {
   
        public List<CharacterUnit> characterUnits = new List<CharacterUnit>(); 
        public float navAgentSpeed=0.3f;
        public float navAgentMaxSpeed=7f;
      
        
    
        [SerializeField] protected TextMeshPro countTxt;
    
        protected event Action OnCountChanged;

   
 
   
        [SerializeField] public PoolTypes.CharacterTypes characterType;

        public void RemoveUnit(CharacterUnit unit)
        {
         
            // Count--;
            characterUnits.Remove(unit);
    
            OnCountChanged?.Invoke();
        }

        private void OnEnable()
        {
            OnCountChanged += SetCountText;
        }

        private void OnDisable()
        {
      
            if(!gameObject.scene.isLoaded) return;
            OnCountChanged -= SetCountText;
        }
    
        public void AddUnit(CharacterUnit unit)
        {
     
            characterUnits.Add(unit);
       
            OnCountChanged?.Invoke();
        }

        protected void SetCountText()
        {

            countTxt.text = characterUnits.Count.ToString();

            if (characterUnits.Count == 0)
                countTxt.enabled = false;

        }
   
 

   
    
        public void SetTargetNavAgentAllUnit(Transform target)
        {
            for (int i = 0; i < characterUnits.Count; i++)
            {
                characterUnits[i].destination = target;
            }
        }

        public void SetNavAgentSpeed(float speed)
        {
            for (int i = 0; i < characterUnits.Count; i++)
            {
                characterUnits[i].agent.speed = speed;
            }
        }
   
    
    }
}
