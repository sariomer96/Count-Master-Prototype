using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdManager : MonoBehaviour
{
    public static CrowdManager Instance { get; set; }
 
    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }


    void SpawnCrowd(int count)
    {
        for (int i = 0; i < count; i++)
        {
             
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
