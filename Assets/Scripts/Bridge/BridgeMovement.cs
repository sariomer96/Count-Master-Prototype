using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Bridge
{
    public class BridgeMovement : MonoBehaviour
    {
        [SerializeField] private float moveRate = 2f;

        [SerializeField] private float speed = 5f;
 
        IEnumerator Start()
        {
            float random = Random.Range(0.5f, 1.5f);
            yield return new WaitForSeconds(random);
            transform.DOMoveX(moveRate, speed).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear).SetSpeedBased(true);
        }
 
    }
}
