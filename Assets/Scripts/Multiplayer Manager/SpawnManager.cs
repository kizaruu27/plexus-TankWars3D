using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    
    void Start()
    {
        PhotonNetwork.Instantiate(playerPrefab.name, transform.position, transform.rotation);
    }
}
