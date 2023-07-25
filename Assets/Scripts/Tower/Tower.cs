using Colony;
using Managers;
using UnityEngine;

namespace Tower
{
    public class Tower : MonoBehaviour
    {
    
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("stair"))
            {
                Placement();
                CheckLastTower();
            }
        }

        void Placement()
        {
            transform.SetParent(null);
            MakeTower.towerList.Remove(gameObject);
        }

        void CheckLastTower()
        {
            if (MakeTower.towerList.Count == 0)
                GameManager.Instance.OnLevelEnd();
            
        }
    
    }
}
