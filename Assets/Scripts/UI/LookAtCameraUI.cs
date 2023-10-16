using UnityEngine;

namespace TankWars3D
{
    public class LookAtCameraUI : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;

        private void Awake()
        {
            mainCamera = Camera.main;
        }

        void LateUpdate()
        {
            transform.LookAt(mainCamera.transform);
        }
    }
}

