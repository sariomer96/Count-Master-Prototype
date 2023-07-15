using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
 

public class BuildTower : MonoBehaviour
{
    [SerializeField] int perRowMaxHumanCount;
    [SerializeField] float distanceBetweenHumans;
  [SerializeField]  List<int> towerCountList;
   [SerializeField] List<GameObject> towerList=new List<GameObject>();
 
      private Character _character;

    private void Start()
    {
        towerCountList = new List<int>();
  
        _character = GetComponent<Character>();
     
        //Build();

    }
   
    public  void Build()
    {
       
        FillTowerList();
        StartCoroutine(nameof(BuildRoutine));
 
    }
    void FillTowerList()
    {
        int humanCount = _character.characterUnits.Count;

        for (int i = 1; i <= perRowMaxHumanCount; i++)
        {
            if (humanCount < i)
            {
                break;
            }
            humanCount -= i;
            towerCountList.Add(i);
        }
        for (int i = perRowMaxHumanCount; i > 0; i--)
        {
            if (humanCount >= i)
            {
                humanCount -= i;
                towerCountList.Add(i);
                i++;
            }
        }
        towerCountList.Sort();
    }
    IEnumerator BuildRoutine()
    {
        int towerId = 0;
        Vector3 sum;
        GameObject tower;

        var position = transform.position;
        float posY = position.y;
        float posZ = position.z;
        
        position = new Vector3(0,posY,posZ);
        transform.position = position;

        foreach (int towerHumanCount in towerCountList)
        {
          
            foreach (GameObject character in towerList)
            {
                character.transform.localPosition += Vector3.up;
            }
            tower = new GameObject("Tower" + towerId);
            tower.transform.parent = transform;
            tower.transform.localPosition = new Vector3(0, 0, 0);
            towerList.Add(tower);
            
            sum = Vector3.zero;
            float tmpCount = 0;
         
            for (int i = 0; i < _character.characterUnits.Count; i++)
            {
                Transform playerUnit = _character.characterUnits[i].transform;
                     
                var playerUnitTransform = playerUnit.transform;
                
                playerUnitTransform.parent = tower.transform;
              
                print(playerUnitTransform.parent.name);
                playerUnitTransform.localPosition = new Vector3(tmpCount * distanceBetweenHumans, 0, 0);
                    sum += playerUnitTransform.position;
                    tmpCount++;
                    i--;
                    if (tmpCount >= towerHumanCount)
                        break;  
                   
                 
            }

            float moveX = -sum.x / towerHumanCount;
            var towerPosition = tower.transform.position;
            float moveY = towerPosition.y;
            float moveZ = towerPosition.z;
            
            Vector3 movePos= new Vector3(moveX,moveY,moveZ);
            
            tower.transform.DOMove(movePos, 0.15f);
       
            sum = Vector3.zero;
            towerId++;
            yield return new WaitForSeconds(0.1f);
        }
     
       
    }
}
