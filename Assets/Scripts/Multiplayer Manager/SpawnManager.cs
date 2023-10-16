using Photon.Pun;
using UnityEngine;

namespace TankWars3D
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private GameObject playerPrefab;
    
        void Start()
        {
            PhotonNetwork.Instantiate(playerPrefab.name, transform.position, transform.rotation);
        }
    }
}


