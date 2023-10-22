using System;
using UnityEngine;

namespace TankWars3D
{
    public class BulletMove : MonoBehaviour
    {
        [SerializeField] private float bulletSpeed = 5f;
        [SerializeField] private float bulletLifeTime = 8f;

        private void Start()
        {
            Destroy(gameObject, bulletLifeTime);
        }

        private void Update()
        {
            transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
        }
    }
}

