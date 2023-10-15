using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PhotonView view;
    
    void Start()
    {
        if (view.IsMine)
            gameObject.name = PhotonNetwork.NickName;
    }
    
}
