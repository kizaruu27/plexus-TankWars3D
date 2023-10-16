using Photon.Pun;
using UnityEngine;

namespace TankWars3D
{
    public class SpawnManager : MonoBehaviour
    {
        public Transform spawnPointMaster;
        public Transform spawnPointClient;
        
        [SerializeField] private GameObject playerPrefab;
    
        void Start()
        {
            if (PhotonNetwork.IsMasterClient)
                PhotonNetwork.Instantiate(playerPrefab.name, spawnPointMaster.position, spawnPointMaster.rotation);
            else
                PhotonNetwork.Instantiate(playerPrefab.name, spawnPointClient.position, spawnPointClient.rotation);
        }
    }
}


