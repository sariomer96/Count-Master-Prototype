using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
 [SerializeField]   private LevelManager _levelManager;

 private void Start()
 {
     _levelManager.CreateLevel();
 }
     
    public void LevelWon()
    {
       
        SceneManager.LoadScene("Game");
        PlayerPrefs.SetInt("CurrentLevel", PlayerPrefs.GetInt("CurrentLevel") + 1);
    }

    public void LevelFail()
    {
        
        SceneManager.LoadScene("Game");
    }
  

  
}
