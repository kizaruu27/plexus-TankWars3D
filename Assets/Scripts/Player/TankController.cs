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
        [SerializeField] private PlayerHealth health;
        [SerializeField] private SpawnManager spawnManager;

        [SerializeField] private float tankSpeed = 15f;
        [SerializeField] private float rotationSpeed = 20f;

        private void OnEnable()
        {
            health.OnDeathEvent += TankRespawn;
        }

        private void OnDisable()
        {
            health.OnDeathEvent -= TankRespawn;
        }

        private void Awake()
        {
            spawnManager = FindObjectOfType<SpawnManager>();
        }

        private void LateUpdate()
        {
            if (view.IsMine) 
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

        void TankRespawn()
        {
            if (PhotonNetwork.IsMasterClient)
                transform.position = spawnManager.spawnPointMaster.position;
            else
                transform.position = spawnManager.spawnPointClient.position;
        }
    }
}


