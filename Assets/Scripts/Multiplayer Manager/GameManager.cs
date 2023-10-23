using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TankWars3D
{
    public class GameManager : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Camera initiateCamera;
        
        private void Awake()
        {
            initiateCamera.gameObject.SetActive(false);
        }

        public void LeaveGame()
        {
            PhotonNetwork.LeaveRoom();
        }

        public override void OnLeftRoom()
        {
            SceneManager.LoadScene("MatchmakingMenu");
        }
    }

}
