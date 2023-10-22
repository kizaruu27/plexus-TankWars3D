using System;
using Photon.Pun;
using UnityEngine;

namespace TankWars3D
{
    public class TakeDamage : MonoBehaviour
    {
        public event Action OnTakeDamageEvent;
        public event Action OnTakeDamageOnRocket;
        [SerializeField] private string targetTag;
        
        private void OnTriggerEnter(Collider col)
        {
            if (col.CompareTag(targetTag))
            {
                OnTakeDamageEvent?.Invoke();
                Destroy(col.gameObject);
            }

            if (col.CompareTag("RocketBullet"))
            {
                OnTakeDamageOnRocket?.Invoke();
                Destroy(col.gameObject);
            }
        }
    }
}

