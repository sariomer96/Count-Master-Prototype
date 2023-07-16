using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class Btsf : MonoBehaviour
{
    [SerializeField] int perRowMaxHumanCount;
    [SerializeField] float distanceBetweenHumans;
   [SerializeField] List<int> towerCountList;
  [SerializeField] public static List<GameObject> towerList=new List<GameObject>();
  [SerializeField] private Transform towerTransform;
  [SerializeField] private GameObject towerPrefab;
  private List<GameObject> testList = new List<GameObject>();
  [SerializeField] private float rate;
    Character _character;
 
    bool move;

    private void Start()
    {
        _character = GetComponent<Character>();
        towerCountList = new List<int>();

       

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


    
    public void ParentSet()
    {
        towerList[0].transform.SetParent(null);
    }

    // ReSharper disable Unity.PerformanceAnalysis
    IEnumerator BuildTowerCoroutine()
    {
        int towerId = 0;
        Vector3 sum;
        GameObject tower;
        float tempTowerHumanCount;
        transform.position = new Vector3(0, transform.position.y, transform.position.z);

        int height = 0;
        for (int i = towerCountList.Count-1; i>=0; i--)
        { 
          
          //  tower = new GameObject("Tower" + towerId);
            tower=  Instantiate(towerPrefab, Vector3.zero, Quaternion.identity);
            tower.transform.parent = towerTransform;
            tower.transform.localPosition = new Vector3(0, height, 0);
            towerList.Add(tower);
             
            height++;
            sum = Vector3.zero;
            tempTowerHumanCount = 0;
            List<CharacterUnit> unitControllers = new List<CharacterUnit>();
            
  
            unitControllers=_character.characterUnits;
            int count = unitControllers.Count;
            for (int j = 0; j< count;j++)
            {
                Transform child = unitControllers[0].transform;
                 
          
                child.SetParent(tower.transform);
                child.parent = tower.transform; 
                child.localPosition = new Vector3(tempTowerHumanCount * distanceBetweenHumans, 0, 0);
                sum += child.position;
                tempTowerHumanCount++;
             
                unitControllers.RemoveAt(0);
                if (tempTowerHumanCount >= towerCountList[i])
                {
                    break;
                }
                
            }
            tower.transform.position = new Vector3(-sum.x / towerCountList[i], tower.transform.position.y, tower.transform.position.z);
            sum = Vector3.zero;
            towerId++;
            yield return new WaitForSeconds(0.1f);
        }
 
       

  
        PlayerMovement pm=_character.GetComponent<PlayerMovement>();
       
          pm.StartMove();
     
        move = true;
    }
}
