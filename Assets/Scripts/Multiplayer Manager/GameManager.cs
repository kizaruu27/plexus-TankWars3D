using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankWars3D
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Camera initiateCamera;
        
        private void Awake()
        {
            initiateCamera.gameObject.SetActive(false);
        }
    }

}
