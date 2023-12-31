using System;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    [CreateAssetMenu(fileName = "PoolTypes", menuName = "PoolTypes/Pool", order = 1)]
    public class PoolTypes : ScriptableObject
    { 
    
        [Serializable]
        public class Pool
        {
            public GameObject character;
            public int poolSize;
            public CharacterTypes Types;
        }
    
        public List<Pool> characterPool = new List<Pool>();
    
        public enum CharacterTypes
        {
            MainPlayer,
            Enemy,
        
        }
    }
}


