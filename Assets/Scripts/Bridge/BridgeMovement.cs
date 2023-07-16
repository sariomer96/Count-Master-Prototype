using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BridgeMovement : MonoBehaviour
{
    [SerializeField] private float moveRate = 2f;

    [SerializeField] private float speed = 5f;
 
    void Start()
    {
        transform.DOMoveX(moveRate, speed).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear).SetSpeedBased(true);
    }
 
}
