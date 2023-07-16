using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{

    [SerializeField] private GameObject retryButton;

    [SerializeField] private GameObject nextButton;
    public static UiManager Instance { get; set; }
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance==null)
            Instance = this;
        
    }

    public void Retry()
    {
        retryButton.SetActive(true);
    }

    public void Next()
    {
        nextButton.SetActive(true);
    }

    
    
}
