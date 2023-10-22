using Photon.Pun;
using UnityEngine;
using UnityEngine.Serialization;

namespace TankWars3D
{
    public class SpawnManager : MonoBehaviour
    {
        public Transform spawnPointMaster;
        public Transform spawnPointClient;
        
        [SerializeField] private GameObject masterPrefab;
        [SerializeField] private GameObject clientPrefab;
    
        void Start()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.Instantiate(masterPrefab.name, spawnPointMaster.position, spawnPointMaster.rotation);
            }
            else
            {
                PhotonNetwork.Instantiate(clientPrefab.name, spawnPointClient.position, spawnPointClient.rotation);
            }
        }
    }
}


