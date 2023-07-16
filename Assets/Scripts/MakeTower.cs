using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class MakeTower : MonoBehaviour
{
    [SerializeField] private int _perRowMaxHumanCount;
    [SerializeField] private float _distanceBetweenHumans;
   [SerializeField] private List<int> towerCountList;
   [SerializeField] private Transform _towerTransform;
   [SerializeField] private GameObject _towerPrefab;
   private Colony _colony;
   [SerializeField] private CinemachineController _camera;
   
   public static List<GameObject> towerList=new List<GameObject>();

 

    private void Start()
    {
        _colony = GetComponent<Colony>();
        towerCountList = new List<int>();

    }
   
   
    public  void Build()
    {
        FillTowerList();
        StartCoroutine(BuildTowerCoroutine());
    }
    void FillTowerList()
    {
        int humanCount = _colony.characterUnits.Count;

        for (int i = 1; i <= _perRowMaxHumanCount; i++)
        {
            if (humanCount < i)
                break;
            
            humanCount -= i;
            towerCountList.Add(i);
        }
        for (int i = _perRowMaxHumanCount; i > 0; i--)
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
        
        var position = transform.position;
        position = new Vector3(0, position.y, position.z);
        transform.position = position;

        int height = 0;
        for (int i = towerCountList.Count-1; i>=0; i--)
        { 
           
            tower=  Instantiate(_towerPrefab, Vector3.zero, Quaternion.identity);
            tower.transform.parent = _towerTransform;
            tower.transform.localPosition = new Vector3(0, height, 0);
            towerList.Add(tower);
             
            height++;
            sum = Vector3.zero;
            tempTowerHumanCount = 0;
          
            int count = _colony.characterUnits.Count;
            for (int j = 0; j< count;j++)
            {
                Transform child = _colony.characterUnits[0].transform;
                
                child.SetParent(tower.transform);
                child.parent = tower.transform; 
                child.localPosition = new Vector3(tempTowerHumanCount * _distanceBetweenHumans, 0, 0);
                
                sum += child.position;
                tempTowerHumanCount++;
             
                _colony.characterUnits.RemoveAt(0);
                if (tempTowerHumanCount >= towerCountList[i])
                    break;
                
            }

            var towerPos = tower.transform.position;
            towerPos = new Vector3(-sum.x / towerCountList[i], towerPos.y, towerPos.z);
            tower.transform.position = towerPos;
            
            sum = Vector3.zero;
            towerId++;
            yield return new WaitForSeconds(0.1f);
        }
  
        PlayerColonyController playerColony=_colony.GetComponent<PlayerColonyController>();
       
        playerColony.StartMove();
           _camera.SetTowerTarget(towerList[towerList.Count-1].transform);
        
    }
}
