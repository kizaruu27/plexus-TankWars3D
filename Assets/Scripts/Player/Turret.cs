using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
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
        [SerializeField] private GameObject rocketPrefab;

        public int currentAmunition;
        public int maxAmmuntion = 7;
        [SerializeField] private TextMeshProUGUI ammunitionUI;

        [SerializeField] private TankController tank;

        [SerializeField] private bool useRocket;
        
        private void OnEnable()
        {
            inputReader.OnShootEvent += Shoot;
            tank.OnGetBulletItem += AddBullet;
            tank.OnGetRocketItem += ChangeBullet;
        }

        private void OnDisable()
        {
            inputReader.OnShootEvent -= Shoot;
            tank.OnGetBulletItem -= AddBullet;
            tank.OnGetRocketItem -= ChangeBullet;
        }

        private void Start()
        {
            currentAmunition = maxAmmuntion;
        }

        private void Update()
        {
            RotateTurret();
            
            if (view.IsMine)
                ammunitionUI.text = $"{currentAmunition} / {maxAmmuntion}";
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
            {
                if (!useRocket)
                {
                    if (currentAmunition <= 0)
                        return;
                
                    view.RPC("RpcShoot", RpcTarget.All);
                    currentAmunition--;
                }
                else
                {
                    view.RPC("RpcRocketShoot", RpcTarget.All);
                    useRocket = false;
                }
            }
        }

        [PunRPC]
        void RpcShoot()
        { 
            Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            AudioManager.instance.PlayAudioShoot();
        }

        [PunRPC]
        void RpcRocketShoot()
        {
            Instantiate(rocketPrefab, shootPoint.position, shootPoint.rotation);
            AudioManager.instance.PlayAudioShoot();
        }

        void AddBullet()
        {
            currentAmunition = maxAmmuntion;
        }

        void ChangeBullet()
        {
            useRocket = true;
        }
    }
}

