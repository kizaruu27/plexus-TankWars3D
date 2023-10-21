using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class RespawnUICountdown : MonoBehaviour
{
    [SerializeField] private float countdownTime = 3;
    [SerializeField] private TextMeshProUGUI countdownTxt;
    [SerializeField] private GameObject respawnUI;
    
    [SerializeField]  private PhotonView view;
    
    private void Start()
    {
        if (view.IsMine)
        {
            transform.parent = null;
            gameObject.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        string time = countdownTime.ToString("F0");
        countdownTxt.text = time;

        countdownTime -= Time.deltaTime;

        if (countdownTime <= 0)
        {
            countdownTime = 3;
            gameObject.SetActive(false);
        }
    }
}
