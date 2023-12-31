using Photon.Pun;
using UnityEngine;

namespace TankWars3D
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private PhotonView view;

        private void Awake()
        {
            if (view.IsMine)
            {
                transform.parent = null;
            }
            else
            {
                Destroy(gameObject);
            }
            
        }
    }
}

