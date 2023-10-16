using Photon.Pun;
using TMPro;
using UnityEngine;

namespace TankWars3D
{
    public class NicknameUI : MonoBehaviourPunCallbacks
    {
        [SerializeField] private TextMeshProUGUI nicknameTxt;
    
        private void Start()
        {
            nicknameTxt.text = photonView.Owner.NickName;
        }
    }
}

