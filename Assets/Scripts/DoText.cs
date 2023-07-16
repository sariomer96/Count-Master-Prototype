using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public static class DoText 
{
    // Start is called before the first frame update
   
    public static void SetText(TextMeshPro countTxt,int count)
    {
        int a = Int32.Parse(countTxt.text);
        DOTween.To(() => a, x => a = x, count,0.25f).OnUpdate(() =>
            {
                countTxt.text = a.ToString();
                if (a == 0)
                    countTxt.enabled = false;
            }
        );
    }
}
