using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsBehaviour : MonoBehaviour
{
    [SerializeField]
    enum State
    {
        Destructable,
        Undestructable
    }

    [SerializeField] private State wallState;
    [SerializeField] private int wallHealth;
    [SerializeField] private ParticleSystem explosionEffect;

    private void Start()
    {
        wallHealth = 2;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("MasterBullet") || col.CompareTag("ClientBullet"))
        {
            Destroy(col.gameObject);
            
            switch (wallState)
            {
                case State.Destructable:
                    wallHealth--;

                    if (wallHealth <= 0)
                    {
                        Instantiate(explosionEffect, transform.position, Quaternion.identity);
                        Destroy(gameObject);
                    }
                    
                    break;
                case State.Undestructable:
                    break;
            }
        }
    }
}
