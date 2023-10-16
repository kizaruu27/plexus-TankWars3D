using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.Serialization;

namespace TankWars3D
{
    public class Turret : MonoBehaviour
    {
        public float rotationSpeed = 5.0f;
        [SerializeField] private Transform shootPoint;
        [SerializeField] private PhotonView view;
        [SerializeField] private InputReader inputReader;
        [SerializeField] private GameObject bulletPrefab;

        private void OnEnable()
        {
            inputReader.OnShootEvent += Shoot;
        }

        private void OnDisable()
        {
            inputReader.OnShootEvent -= Shoot;
        }

        private void Update()
        {
            RotateTurret();
        }

        void RotateTurret()
        {
            if (view.IsMine)
            {
                Vector3 mousePosition = Input.mousePosition;
                Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 20.0f));
        
                Vector3 direction = mouseWorldPosition - transform.position;
                direction.y = 0.0f;
        
                if (direction != Vector3.zero)
                {
                    Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
                }
            }
        }

        void Shoot()
        {
            if (view.IsMine)
                view.RPC("RpcShoot", RpcTarget.All);
        }

        [PunRPC]
        void RpcShoot()
        { 
            Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        }
    }
}

