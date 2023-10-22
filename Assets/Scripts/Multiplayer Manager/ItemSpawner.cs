using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] itemPrefabs;
    [SerializeField] private PhotonView view;
    [SerializeField] private float spawnTime;

    private void Start()
    {
        if (view.IsMine)
            StartCoroutine(SpawnItemsCoroutine());
    }

    IEnumerator SpawnItemsCoroutine()
    {
        int spawnIndex = Random.Range(0, itemPrefabs.Length);
        
        if (view.IsMine)
            view.RPC("RpcSpawnItems", RpcTarget.AllBuffered, spawnIndex);

        yield return new WaitForSeconds(spawnTime);

        StartCoroutine(SpawnItemsCoroutine());
    }

    [PunRPC]
    void RpcSpawnItems(int spawnIndex)
    {
        Instantiate(itemPrefabs[spawnIndex], transform.position, Quaternion.identity);
    }
}
