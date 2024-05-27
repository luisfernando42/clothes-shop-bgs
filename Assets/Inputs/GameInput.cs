using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public EventHandler OnInteractAction;

    private PlayerInputActions playerActions;

    private void Awake()
    {
        playerActions = new PlayerInputActions();
        playerActions.Player.Enable();
        playerActions.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVector()
    {
        Vector2 inputVector = playerActions.Player.Move.ReadValue<Vector2>();
        return inputVector;
    }
}
