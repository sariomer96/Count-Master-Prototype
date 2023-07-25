using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Bridge
{
    public class BridgeMovement : MonoBehaviour
    {
        [SerializeField] private float moveRate = 2f;

        [SerializeField] private float speed = 5f;
 
        void Start()
        {
            float random = Random.Range(0.5f, 2f);
            transform.DOMoveX(moveRate, speed).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear).SetSpeedBased(true).SetDelay(random);
        }
 
    }
}
