using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class BaseUI : MonoBehaviour
{
    [SerializeField] private CinemachineBrain mainCamera;

    private void Start()
    {
    }

    private void LateUpdate()
    {
        mainCamera = FindObjectOfType<CinemachineBrain>();
        transform.LookAt(mainCamera.transform);
    }
}
