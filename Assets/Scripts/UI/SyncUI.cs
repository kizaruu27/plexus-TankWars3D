using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class SyncUI : MonoBehaviour
{
    [SerializeField] private PhotonView view;
    
    private void Awake()
    {
        if (view.IsMine)
            transform.parent = null;
        else 
            Destroy(gameObject);
    }
}
