using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager
{
    private InputControls inputControls;
    
    public Vector2 Movement => inputControls.Player.Movement.ReadValue<Vector2>();

    public InputManager()
    {
        inputControls = new InputControls();
        inputControls.Enable();
        DisableInteraction();

        inputControls.Player.Interact.performed += OnInteractPerformed;
    }

    private void OnInteractPerformed(InputAction.CallbackContext context)
    {
        GameManager.Instance.CheckAndHandleShopUIEnabled();
    }

    public void EnableInteraction()
    {
        inputControls.Player.Interact.Enable();
    }

    public void DisableInteraction()
    {
        inputControls.Player.Interact.Disable();
    }
}
