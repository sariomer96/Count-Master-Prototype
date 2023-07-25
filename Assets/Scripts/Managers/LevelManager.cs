using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        [Header("Test Level")]
        public GameObject testLevel;
        [Header("Level List")]
        public List<GameObject> Levels = new List<GameObject>();

        public   string currentLevel = "CurrentLevel";

        public void CreateLevel()
        {
            if (testLevel != null)
            {
                Instantiate(testLevel, new Vector3(0, 0, 0), Quaternion.identity);
                return;
            }
            else
            {
                if (PlayerPrefs.GetInt(currentLevel) == 0)
                {
                    Instantiate(Levels[0], new Vector3(0, 0, 0), Quaternion.identity);
            
                }
                else
                {
                    if (PlayerPrefs.GetInt(currentLevel) >= Levels.Count)
                        PlayerPrefs.SetInt(currentLevel, 0);
                
                    Instantiate(Levels[PlayerPrefs.GetInt(currentLevel)], new Vector3(0, 0, 0), Quaternion.identity);
                }

            }
        }

        public void SetLevel()
        {
            PlayerPrefs.SetInt(currentLevel, PlayerPrefs.GetInt(currentLevel) + 1);
        }
    }
    
  
}