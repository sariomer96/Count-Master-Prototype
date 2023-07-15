using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Btsf : MonoBehaviour
{
    [SerializeField] int perRowMaxHumanCount;
    [SerializeField] float distanceBetweenHumans;
    List<int> towerCountList;
  [SerializeField]  List<GameObject> towerList;
    [SerializeField] Character _character;
 
    bool move;

    private void Start()
    {
        _character = GetComponent<Character>();
        towerCountList = new List<int>();
        towerList = new List<GameObject>();
       //Build();
        
    }
   
   
    public  void Build()
    {
 
        FillTowerList();
        StartCoroutine(BuildTowerCoroutine());
       
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



    IEnumerator BuildTowerCoroutine()
    {
        int towerId = 0;
        Vector3 sum;
        GameObject tower;
        float tempTowerHumanCount;
        transform.position = new Vector3(0, transform.position.y, transform.position.z);

        foreach (int towerHumanCount in towerCountList)
        {
            foreach (GameObject child in towerList)
            {
                child.transform.localPosition += Vector3.up;
            }
            tower = new GameObject("Tower" + towerId);
            tower.transform.parent = transform;
            tower.transform.localPosition = new Vector3(0, 0, 0);
            towerList.Add(tower);
            sum = Vector3.zero;
            tempTowerHumanCount = 0;
            List<CharacterUnit> unitControllers = new List<CharacterUnit>();
            
            
              unitControllers=_character.characterUnits;
              int count = unitControllers.Count;
            for (int i = 0; i < count; i++)
            {
                Transform child = unitControllers[0].transform;
                 
          
                child.SetParent(tower.transform);
                child.parent = tower.transform; 
                child.localPosition = new Vector3(tempTowerHumanCount * distanceBetweenHumans, 0, 0);
                sum += child.position;
                tempTowerHumanCount++;
             
                unitControllers.RemoveAt(0);
                if (tempTowerHumanCount >= towerHumanCount)
                {
                    break;
                }
                
            }
            tower.transform.position = new Vector3(-sum.x / towerHumanCount, tower.transform.position.y, tower.transform.position.z);
            sum = Vector3.zero;
            towerId++;
            yield return new WaitForSeconds(0.1f);
           
        }
     
        move = true;
    }
}
