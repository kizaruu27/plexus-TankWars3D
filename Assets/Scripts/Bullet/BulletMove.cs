using System;
using UnityEngine;

namespace TankWars3D
{
    public class BulletMove : MonoBehaviour
    {
        [SerializeField] private float bulletSpeed = 5f;
        [SerializeField] private float bulletLifeTime = 8f;
        [SerializeField] private ParticleSystem bulletExplosion;

        private void Start()
        {
            Destroy(gameObject, bulletLifeTime);
        }

        private void Update()
        {
            transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
        }

        private void OnDestroy()
        {
            Instantiate(bulletExplosion, transform.position, Quaternion.identity);
        }
    }
}

