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
        public bool canDamage;

        private bool isTakenDamage;

        [SerializeField] private TankController tank;

        public event Action OnDeathEvent;

        private void OnEnable()
        {
            takeDamage.OnTakeDamageEvent += TakeDamage;
            takeDamage.OnTakeDamageOnRocket += RocketDamage;
            tank.OnGetHealthItem += AddHealth;
        }

        private void OnDisable()
        {
            takeDamage.OnTakeDamageEvent -= TakeDamage;
            takeDamage.OnTakeDamageOnRocket -= RocketDamage;
            tank.OnGetHealthItem -= AddHealth;
        }

        private void Awake()
        {
            canDamage = true;
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
            if (canDamage)
            {
                currentHealth -= 50;

                if (currentHealth <= 0)
                {
                    OnDeathEvent?.Invoke();
                }
            }
        }

        void RocketDamage()
        {
            if (canDamage)
            {
                currentHealth -= 100;

                if (currentHealth <= 0)
                {
                    OnDeathEvent?.Invoke();
                }
            }
        }

        void AddHealth()
        {
            currentHealth = maxHealth;
        }
    }
}

