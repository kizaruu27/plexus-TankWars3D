using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    private Controls controls;

    public Vector2 MovementValue { get; private set; }
    public Vector2 MouseValue { get; private set; }
    public event Action OnShootEvent;

    private void Start()
    {
        controls = new Controls();
        controls.Player.SetCallbacks(this);
        
        controls.Player.Enable();
    }

    private void OnDestroy()
    {
        controls.Player.Disable();
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnShootEvent?.Invoke();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        MouseValue = context.ReadValue<Vector2>();
    }
}

