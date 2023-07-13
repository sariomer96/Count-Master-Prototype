using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

 

public class CrowdSpawner : MonoBehaviour
{
    private Character character;
    
    [SerializeField] private float _density;
    [SerializeField] private float _radius;
    public List<CharacterUnit> _characterUnits = new List<CharacterUnit>();

    [SerializeField] private int count;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<Character>();
        
        SpawnCrowd(count);
        SortCrowd();
        
    }
    
    

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnCrowd(count);
            SortCrowd();
        }
      
    }

    void SpawnCrowd(int count)
    {
        for (int i = 0; i < count; i++)
        {
            ObjectPool.Instance.GetPooledObject((int)character.characterType,transform);
          
        }
    }

    
    void SortCrowd()
    {
        
        for (int i = 0; i < _characterUnits.Count; i++)
        {
           
            
            Vector2 pos = new Vector2(_density  * Mathf.Cos(i * _radius),
                _density*Mathf.Sin(i*_radius));

            Vector3 newPos = new Vector3(pos.x, 0, pos.y);

            _characterUnits[i].transform.DOLocalMove(newPos, 0.25f);
             
        }
    }
    
   
}
