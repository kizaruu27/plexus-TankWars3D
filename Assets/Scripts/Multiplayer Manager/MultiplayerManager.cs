using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TankWars3D
{
    public class MultiplayerManager : MonoBehaviourPunCallbacks
    {
        [SerializeField] private GameObject matchmakingUI;
        [SerializeField] private GameObject loadingScreen;
        [SerializeField] private TMP_InputField nicknameInput;
        [SerializeField] private GameObject waitingUI;
    
        private bool isJoinRoom;
    
        private void Awake()
        {
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.AutomaticallySyncScene = true;
            
            isJoinRoom = false;
            matchmakingUI.SetActive(false);
            loadingScreen.SetActive(true);
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
            Debug.Log($"Nickname: {PhotonNetwork.NickName}");
            waitingUI.SetActive(true);
            // SceneManager.LoadSceneAsync("WaitingScene", LoadSceneMode.Additive);
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
}


