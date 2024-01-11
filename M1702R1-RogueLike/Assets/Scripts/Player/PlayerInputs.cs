using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PlayerInputs : MonoBehaviour
{

    public static PlayerInputs Instance;

    private PlayerControls playerControls;

    private PlayerMovement playerMovement;

    public Vector2 direction;
    public Vector2 lastMoveDirection;

    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        playerMovement = GetComponent<PlayerMovement>();

        playerControls = new PlayerControls();

        playerControls.Gameplay.Move.performed += ReadMovement;
        playerControls.Gameplay.Move.canceled += ReadMovement;
        playerControls.Gameplay.FollowMouse.performed += ReadMousePosition;
    }
    public void ReadMovement(InputAction.CallbackContext context)
    {
        var input = context.ReadValue<Vector2>();
        StartCoroutine(ProcessMovement(input));
    }
    private void ReadMousePosition(InputAction.CallbackContext context)
    {
        Vector3 mousePosition = GetMousePosition(context);

        var mouseDirection = mousePosition - transform.position;
        mouseDirection.Normalize();

        lastMoveDirection.x = mouseDirection.x;
        lastMoveDirection.y = mouseDirection.y;

        playerMovement.Move(direction, lastMoveDirection);

    }

    private Vector2 GetMousePosition(InputAction.CallbackContext context)
    {
        Vector3 mousePos = context.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
    public IEnumerator ProcessMovement(Vector2 input)
    {
        lastMoveDirection.x = direction.x;
        lastMoveDirection.y = direction.y;

        yield return new WaitForSeconds(0.05f);

        direction.x = input.x;
        direction.y = input.y;

        playerMovement.Move(direction, lastMoveDirection);
    }






}
