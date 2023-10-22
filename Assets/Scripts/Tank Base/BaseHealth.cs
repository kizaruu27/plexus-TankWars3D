using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TankWars3D
{
    public class BaseHealth : MonoBehaviour
    {
        public enum BaseState
        {
            MasterBase,
            ClientBase
        }
        
        [SerializeField] BaseState baseState;
        
        [SerializeField] private int maxBaseHealth;
        private int currentBaseHealth;

        [SerializeField] private Slider healthSlider;
        [SerializeField] private GameObject gameOverUI;
        [SerializeField] private TextMeshProUGUI winText;
        [SerializeField] private string targetTag;

        private void Awake()
        {
            currentBaseHealth = maxBaseHealth;
            healthSlider.maxValue = maxBaseHealth;
        }

        private void Update()
        {
            healthSlider.value = currentBaseHealth;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(targetTag))
            {
                TakeDamage();
                Destroy(other.gameObject);
            }
        }

        void TakeDamage()
        {
            currentBaseHealth--;

            if (currentBaseHealth <= 0)
            {
                gameOverUI.SetActive(true);

                switch (baseState)
                {
                    case BaseState.MasterBase:
                        if (!PhotonNetwork.IsMasterClient)
                            winText.text = "You Win";
                        else
                            winText.text = "You Lose";
                        break;
                    case BaseState.ClientBase:
                        if (PhotonNetwork.IsMasterClient)
                            winText.text = "You Win";
                        else
                            winText.text = "You Lose";
                        break;
                }
                
                Destroy(gameObject);
            }
        }
    }
}
