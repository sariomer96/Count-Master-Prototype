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
   

        public void CreateLevel()
        {
            if (testLevel != null)
            {
                Instantiate(testLevel, new Vector3(0, 0, 0), Quaternion.identity);
                return;
            }
            else
            {
                if (PlayerPrefs.GetInt("CurrentLevel") == 0)
                {
                    Instantiate(Levels[0], new Vector3(0, 0, 0), Quaternion.identity);
            
                }
                else
                {
                    if (PlayerPrefs.GetInt("CurrentLevel") >= Levels.Count)
                        PlayerPrefs.SetInt("CurrentLevel", 0);
                
                    Instantiate(Levels[PlayerPrefs.GetInt("CurrentLevel")], new Vector3(0, 0, 0), Quaternion.identity);
                }

            }
        }
    }
}