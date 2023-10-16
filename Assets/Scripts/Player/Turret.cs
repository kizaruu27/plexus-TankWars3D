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

        private void Update()
        {
            if (view.IsMine)
                RotateTurret();
        }

        void RotateTurret()
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 20.0f));
        
            Vector3 direction = mouseWorldPosition - transform.position;
            direction.y = 0.0f;
        
            if (direction != Vector3.zero)
            {
                // Rotate the object to face the cursor (y-axis only)
                Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
            }

        }
    }
}

