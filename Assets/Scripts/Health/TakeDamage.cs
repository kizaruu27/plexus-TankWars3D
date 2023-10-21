using System;
using Photon.Pun;
using UnityEngine;

namespace TankWars3D
{
    public class TakeDamage : MonoBehaviour
    {
        public event Action OnTakeDamageEvent;
        
        private void OnTriggerEnter(Collider col)
        {
            if (col.CompareTag("Bullet"))
            {
                OnTakeDamageEvent?.Invoke();
                Destroy(col.gameObject);
            }
        }
    }
}

