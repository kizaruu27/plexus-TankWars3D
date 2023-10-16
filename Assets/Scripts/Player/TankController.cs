using System;
using Photon.Pun;
using UnityEngine;

namespace TankWars3D
{
    public class TankController : MonoBehaviour
    {
        [SerializeField] private PhotonView view;
        [SerializeField] private InputReader inputReader;
        [SerializeField] private Rigidbody rb;

        [SerializeField] private float tankSpeed = 15f;
        [SerializeField] private float rotationSpeed = 20f;

        private void LateUpdate()
        {
            Move();
        }

        void Move()
        {
            // movement
            Vector3 input = new Vector3();
            input.z = inputReader.MovementValue.y;
            input.x = inputReader.MovementValue.x;
            
            transform.position += transform.forward * input.z * tankSpeed * Time.deltaTime;
            
            // rotation
            Quaternion TargetRotation = transform.rotation * Quaternion.Euler(Vector3.up * (rotationSpeed * input.x * Time.deltaTime));
            rb.MoveRotation(TargetRotation);
        }
    }
}


