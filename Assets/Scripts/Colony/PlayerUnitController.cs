using System.Collections;
using ObjectPool;
using UnityEngine;

namespace Colony
{
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
                ReturnPool(other.transform);
                KillUnit();
                HideUnit(other.gameObject);
            }
        }

        void HideUnit(GameObject hitObject)
        {
            hitObject.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
        void ReturnPool(Transform hit)
        {
            CharacterUnit enemy=hit.GetComponent<CharacterUnit>();
            ObjectPool.ObjectPool.Instance.ReturnToPool(this,PoolTypes.CharacterTypes.MainPlayer);
            ObjectPool.ObjectPool.Instance.ReturnToPool(enemy,PoolTypes.CharacterTypes.Enemy);
        }

        IEnumerator Fall()
        {
  
            agent.enabled = false;
           
             rigidBody.constraints = RigidbodyConstraints.None;
            rigidBody.useGravity = true;
          
            playerColony.RemoveUnit(this);
            playerColony.FailCheck();
            Colony colony = transform.GetComponentInParent<Colony>();
            transform.SetParent(null);
            yield return new WaitForSeconds(1f);
         
         
            ObjectPool.ObjectPool.Instance.ReturnToPool(this,colony.characterType);
          
        }
 
    }
}
