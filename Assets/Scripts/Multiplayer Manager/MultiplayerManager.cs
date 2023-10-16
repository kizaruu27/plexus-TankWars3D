using Photon.Pun;
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
    
        private bool isJoinRoom;
    
        private void Awake()
        {
            isJoinRoom = false;
            matchmakingUI.SetActive(false);
            loadingScreen.SetActive(true);
        }
    
        private void Start()
        {
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.AutomaticallySyncScene = true;
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
            SceneManager.LoadSceneAsync("WaitingScene", LoadSceneMode.Additive);
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


