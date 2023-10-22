using System;
using System.Collections;
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
        [SerializeField] private GameObject tankRenderer;
        [SerializeField] private GameObject playerCanvas;
        [SerializeField] private RespawnUICountdown respawnUI;

        [SerializeField] private float tankSpeed = 15f;
        [SerializeField] private float rotationSpeed = 20f;

        [SerializeField] private Turret turret;

        public event Action OnGetBulletItem;
        public event Action OnGetShieldItem;

        private bool canMove;

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
            canMove = true;
            spawnManager = FindObjectOfType<SpawnManager>();
        }

        private void LateUpdate()
        {
            if (view.IsMine) 
                Move();
        }

        void Move()
        {
            if (canMove)
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

        void TankRespawn()
        {
            if (PhotonNetwork.IsMasterClient)
                StartCoroutine(RespawnCoroutine(spawnManager.spawnPointMaster));
            else
                StartCoroutine(RespawnCoroutine(spawnManager.spawnPointClient));
        }

        IEnumerator RespawnCoroutine(Transform spawnPosition)
        {
            tankRenderer.SetActive(false);
            playerCanvas.SetActive(false);

            if (view.IsMine)
            {
                respawnUI.gameObject.SetActive(true);
            }
            
            canMove = false;
            yield return new WaitForSeconds(3);

            transform.position = spawnPosition.position;
            turret.currentAmunition = turret.maxAmmuntion;
            canMove = true;
            health.currentHealth = health.GetMaxHealth();
            playerCanvas.SetActive(true);
            tankRenderer.SetActive(true);
        }

        private void OnTriggerEnter(Collider col)
        {
            if (col.CompareTag("ItemBullet"))
            {
                OnGetBulletItem?.Invoke();
                Destroy(col.gameObject);
            }

            if (col.CompareTag("ShieldItem"))
            {
                OnGetShieldItem?.Invoke();
                Destroy(col.gameObject);
            }
        }
    }
}


