using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private PhotonView view;
    [SerializeField] private GameObject pauseUI;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            PauseGame();
    }

    public void PauseGame()
    {
        if (view.IsMine)
            pauseUI.SetActive(true);
    }

    public void ResumeGame()
    {
        if (view.IsMine)
            pauseUI.SetActive(false);
    }

    public void QuitMatch()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("MatchmakingMenu");
    }
}
