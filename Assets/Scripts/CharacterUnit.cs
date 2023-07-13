using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUnit : MonoBehaviour
{
    private CrowdSpawner spawner;
  

    // Start is called before the first frame update
    void OnEnable()
    {
        spawner=  GetComponentInParent<CrowdSpawner>();
        spawner._characterUnits.Add(this);
      
    }

    private void OnDisable()
    {
        if (spawner)
            spawner._characterUnits.Remove(this);
      
    }

}
