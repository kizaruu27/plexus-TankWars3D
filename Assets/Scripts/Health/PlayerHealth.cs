using System;
using System.Collections;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace TankWars3D
{
    public class PlayerHealth : MonoBehaviourPunCallbacks
    {
        [SerializeField] private int maxHealth = 200;
        public int currentHealth;
        [SerializeField] private Slider healthSlider;
        [SerializeField] private PhotonView view;

        [SerializeField] private TakeDamage takeDamage;

        private bool isTakenDamage;

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

        public int GetMaxHealth()
        {
            return maxHealth;
        }

        private void TakeDamage()
        {
            currentHealth -= 50;

            if (currentHealth <= 0)
            {
                OnDeathEvent?.Invoke();
            }
        }
    }
}

