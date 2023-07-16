using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStair : MonoBehaviour
{
    // Start is called before the first frame update
 

 
    public GameObject basamakPrefab;
    public int basamakSayisi;
    public float basamakYuksekligi;
    public float basamakGenisligi;
    public float basamakDerinligi;

   IEnumerator  Start()
   {
       yield return null;
        for (int i = 0; i < basamakSayisi; i++)
        {
            Vector3 pozisyon = new Vector3(0f, i * basamakYuksekligi, i * basamakDerinligi);
            
            GameObject basamak = Instantiate(basamakPrefab, Vector3.zero, Quaternion.identity,transform);
            basamak.transform.localPosition = pozisyon;
            basamak.transform.localScale = new Vector3(basamakGenisligi, basamakYuksekligi, basamakDerinligi);
        }
    }
 

}
