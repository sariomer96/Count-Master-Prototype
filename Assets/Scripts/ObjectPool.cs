using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class ObjectPool :MonoBehaviour
{
    [Serializable]
    public class Pool
    {
        public List<GameObject> pooledObjects = new List<GameObject>();
     
    }

    public static ObjectPool Instance { get; set; }
    [SerializeField] public   List<Pool> pools = null;

    [SerializeField] private PoolTypes _poolTypes;
   private void Awake()
   {
       if (Instance == null)
           Instance = this;
       
       InitPool();
   }


   public void InitPool()
    { 

        if (pools.Count>0)
            return; 
        
            for (int i = 0; i < _poolTypes.characterPool.Count; i++)
            {

                pools.Add(new Pool());
                
                SpawnPool(i);
            }
 
    }

    void SpawnPool(int index)
    {
         
        for (int i = 0; i< _poolTypes.characterPool[index].poolSize; i++)
        { 
            GameObject character = Instantiate(  _poolTypes.characterPool[index].character,transform);
           
            character.gameObject.SetActive(false);
           
            pools[index].pooledObjects.Add(character);
          
       
        }
    }
 
 

    public void ReturnToPool(Character character,PoolTypes.CharacterTypes characterTypes)
    {
        character.transform.parent =transform;
        character.gameObject.SetActive(false);
        
        pools[(int)characterTypes].pooledObjects.Add(character.gameObject);
    }
    public Character GetPooledObject(int objectType,Transform parentTransform)
    {
        
        GameObject character = null;
        if (objectType >= pools.Count)
        {
            return null;
        }

       
        if ( pools[objectType].pooledObjects.Count==0)
        {
  
            
             character = Instantiate( _poolTypes.characterPool[objectType].character,transform);
             character.gameObject.SetActive(false);
          
         
            pools[objectType].pooledObjects.Add(character);
        

        }

        character = pools[objectType].pooledObjects[pools[objectType].pooledObjects.Count - 1];    
    
             pools[objectType].pooledObjects.Remove(character);
         
            
      
             character.gameObject.SetActive(true);
             character.transform.parent = parentTransform;
            Character player= character.GetComponent<Character>();
           
            return player;
    }
}