using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;


public class CrowdSpawner : MonoBehaviour
{
    private Colony.Colony _colony;
    [SerializeField] private int _spawnCount;
  
    void Start()
    {
        
         SpawnCrowd(_spawnCount);
    }

    private void Awake()
    {
        _colony = GetComponent<Colony.Colony>();
    }

    public  void SpawnCrowd(int count)
  {
      
    for (int i = 0; i < count; i++) 
        ObjectPool.ObjectPool.Instance.GetPooledObject((int)_colony.characterType,transform);
  }
  
}
