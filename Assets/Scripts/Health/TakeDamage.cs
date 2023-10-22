using System;
using Photon.Pun;
using UnityEngine;

namespace TankWars3D
{
    public class TakeDamage : MonoBehaviour
    {
        public event Action OnTakeDamageEvent;
        [SerializeField] private string targetTag;
        
        private void OnTriggerEnter(Collider col)
        {
            if (col.CompareTag(targetTag))
            {
                OnTakeDamageEvent?.Invoke();
                Destroy(col.gameObject);
            }
        }
    }
}

