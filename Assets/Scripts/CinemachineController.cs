using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CinemachineController : MonoBehaviour
{
    private CinemachineVirtualCamera _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<CinemachineVirtualCamera>();
    }
    public void SetTowerTarget(Transform target)
    {
        _camera.Priority = 10;
        _camera.Follow = target;
    }
    
    
}
