using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MultiplayerManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject matchmakingUI;
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject waitingScreenUI;
    [SerializeField] private TMP_InputField nicknameInput;

    private bool isJoiningRoom;

    private void Awake()
    {
        isJoiningRoom = false;
        matchmakingUI.SetActive(false);
        loadingScreen.SetActive(true);
        waitingScreenUI.SetActive(false);
    }

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    private void Update()
    {
        if (isJoiningRoom)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
            {
                PhotonNetwork.CurrentRoom.IsOpen = false;
                PhotonNetwork.LoadLevel("Level");
            }
        }
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        matchmakingUI.SetActive(true);
        loadingScreen.SetActive(false);
    }

    public override void OnJoinedRoom()
    {
        waitingScreenUI.SetActive(true);
        isJoiningRoom = true;
        Debug.Log($"Nickname: {PhotonNetwork.NickName}");
    }

    public void JoinGame()
    {
        if (nicknameInput.text.Length >= 1)
        {
            PhotonNetwork.NickName = nicknameInput.text;
            PhotonNetwork.JoinRandomOrCreateRoom();
        }
        else
        {
            Debug.Log("Please insert a correct nickname");
        }
    }
}
