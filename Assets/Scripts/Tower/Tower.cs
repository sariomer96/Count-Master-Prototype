using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("stair"))
        {
            transform.SetParent(null);
            Btsf.towerList.Remove(this.gameObject);

            if (Btsf.towerList.Count == 0)
                PlayerMovement.Instance.StopMove();
          
                
        }
    }


    
}
