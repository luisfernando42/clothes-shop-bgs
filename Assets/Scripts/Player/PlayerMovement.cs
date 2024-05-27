using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(100f, 200f)] private float moveSpeed = 200f;
    [SerializeField] private LayerMask interactLayerMask;

    private GameInput gameInput;
    private Rigidbody2D body;
    private Vector2 lastFacedDirection;
    private Interactable interactable;

    private void Awake()
    {
        gameInput = GetComponent<GameInput>();
        body = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
    }

    private void FixedUpdate()
    {
        HandleMovement();
        HandleInteraction();
    }

    private void HandleMovement()
    {
        Vector2 direction = gameInput.GetMovementVector();

        float moveDistance = moveSpeed * Time.deltaTime;

        body.velocity = new Vector2(direction.x, direction.y) * moveDistance;
    }
    private void HandleInteraction()
    {
        Vector2 direction = gameInput.GetMovementVector();

        if(direction != Vector2.zero)
        {
            lastFacedDirection = direction;
        }

        float interactDistance = 2f;
        
        RaycastHit2D raycastHit = Physics2D.Raycast(origin: transform.position, direction: lastFacedDirection, distance: interactDistance, layerMask: interactLayerMask);
        
        if (raycastHit.collider != null)
        {
            SetInteractable(raycastHit.collider.GetComponent<Interactable>());
        }
        else
        {
            SetInteractable(null);
        }
    }

    private void SetInteractable(Interactable interactableObj)
    {
        interactable = interactableObj;
    }

    private void GameInput_OnInteractAction(object sender, EventArgs e)
    {
        if (interactable != null)
        {
            interactable.Interact();
            Debug.Log(interactable.gameObject.name);
        }
    }
}
