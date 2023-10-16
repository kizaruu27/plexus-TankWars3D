using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace TankWars3D
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 200;
        [SerializeField] private int currentHealth;
        [SerializeField] private Slider healthSlider;
        [SerializeField] private PhotonView view;

        [SerializeField] private TakeDamage takeDamage;

        public event Action OnDeathEvent;

        private void OnEnable()
        {
            takeDamage.OnTakeDamageEvent += TakeDamage;
        }

        private void OnDisable()
        {
            takeDamage.OnTakeDamageEvent -= TakeDamage;
        }

        private void Awake()
        {
            currentHealth = maxHealth;
            healthSlider.maxValue = maxHealth;

            if (view.IsMine)
                gameObject.tag = "LocalPlayer";
        }

        private void Update()
        {
            healthSlider.value = currentHealth;
        }
    
        private void TakeDamage()
        { 
            view.RPC("RpcTakeDamage", RpcTarget.All);
        }

        [PunRPC]
        void RpcTakeDamage()
        {
            currentHealth -= 50;

            if (currentHealth <= 0)
            {
                OnDeathEvent?.Invoke();
            }
        }
    }
}

