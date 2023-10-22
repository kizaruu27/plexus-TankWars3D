using System;
using System.Collections;
using System.Collections.Generic;
using TankWars3D;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour
{
    [SerializeField] private TankController tank;
    [SerializeField] private GameObject shieldRenderer;
    [SerializeField] private float shieldTime = 5f;
    [SerializeField] private PlayerHealth tankHealth;

    private void OnEnable()
    {
        tank.OnGetShieldItem += ActivateShield;
    }

    private void OnDisable()
    {
        tank.OnGetShieldItem -= ActivateShield;
    }

    void ActivateShield()
    {
        StartCoroutine(ShieldCoroutine());
    }

    IEnumerator ShieldCoroutine()
    {
        shieldRenderer.SetActive(true);
        tankHealth.canDamage = false;
        yield return new WaitForSeconds(shieldTime);
        tankHealth.canDamage = true;
        shieldRenderer.SetActive(false);
    }
}
