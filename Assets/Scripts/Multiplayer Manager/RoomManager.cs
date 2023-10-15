using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1);

        if (PhotonNetwork.CurrentRoom.PlayerCount > 1)
        {
            yield return new WaitForSeconds(2);
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.LoadLevel("Level");
        }
        else
        {
            StartCoroutine(StartGame());
        }
    }
}
