using UnityEngine;

namespace Colony
{
    public class EnemyColony : Colony
    {
 
   
        private PlayerColonyController _playerColony;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
                SetNavAgentSpeed(navAgentMaxSpeed);
       
        }
    
        private void Start()
        {
            _playerColony =PlayerColonyController.Instance;
            OnCountChanged += FightLoseState;
        }

        public  void FightLoseState()  //for enemy lose
        {
        
            if (characterUnits.Count==0&&_playerColony)
            {
                _playerColony.SetTargetNavAgentAllUnit(_playerColony.transform);
                _playerColony.StartMove();
              
                _playerColony.SetNavAgentSpeed(_playerColony.navAgentSpeed);
            }
        }
    }
}
