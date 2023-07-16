using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("stair"))
        {
            Placement();
            CheckLastTower();
        }
    }

    void Placement()
    {
        transform.SetParent(null);
        MakeTower.towerList.Remove(gameObject);
    }

    void CheckLastTower()
    {
        if (MakeTower.towerList.Count == 0)
        {
            PlayerColonyController.Instance.StopMove();
            UiManager.Instance.Next();
        }
    }
    
}
