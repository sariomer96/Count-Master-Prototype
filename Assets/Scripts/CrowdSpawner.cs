using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;


public class CrowdSpawner : MonoBehaviour
{
    private Character character;
    
    [SerializeField] private float _density;
    [SerializeField] private float _radius;


    [SerializeField] private int count;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<Character>();
        
      
        SpawnCrowd(count);
         
        
    }
    
    

    private void Update()
    {
        if (!CompareTag("Player"))
         return;
        
        if (Input.GetMouseButtonDown(0))
        {
            SpawnCrowd(count);
           
        }
      
    }

  public  void SpawnCrowd(int count)
    {
        for (int i = 0; i < count; i++)
        {
            ObjectPool.Instance.GetPooledObject((int)character.characterType,transform);
         
           
        }
    }
    private Vector3 AddNoiseToObjectPosition(Transform objTrans)
    {
        Vector3 noisedPosition = new Vector3(objTrans.position.x + Random.Range(-0.5f, 0.5f), objTrans.position.y,
            objTrans.position.z + Random.Range(-0.5f, 0.5f));
        return noisedPosition;
    }
    
  
   
}
