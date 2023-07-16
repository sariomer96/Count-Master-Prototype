using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStair : MonoBehaviour
{
    // Start is called before the first frame update
 

 
    public GameObject stairPrefab;
    public int stairCount;
    public float scaleY;
    public float scaleX;
    public float scaleZ;

   IEnumerator  Start()
   {
       yield return null;
        for (int i = 0; i < stairCount; i++)
        {
            Vector3 pozisyon = new Vector3(0f, i * scaleY, i * scaleZ);
            
            GameObject stair = Instantiate(stairPrefab, Vector3.zero, Quaternion.identity,transform);
            stair.transform.localPosition = pozisyon;
            stair.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
        }
    }
 

}
