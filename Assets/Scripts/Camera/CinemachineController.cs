using Cinemachine;
using UnityEngine;

namespace CameraCinemachine
{
    public class CinemachineController : MonoBehaviour
    {
        private CinemachineVirtualCamera _camera;
        // Start is called before the first frame update
        void Awake()
        {
            _camera = GetComponent<CinemachineVirtualCamera>();
        }
        public void SetTowerTarget(Transform target)
        {
            _camera.Priority = 10;
            _camera.Follow = target;
        }
    
    
    }
}
