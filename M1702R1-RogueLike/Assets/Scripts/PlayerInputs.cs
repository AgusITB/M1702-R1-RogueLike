using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PlayerInputs : MonoBehaviour
{

    private PlayerControls playerControls;

    PlayerMovement pMovement;
    PlayerAnimation pAnimation;
    public Weapon weapon;

    private Vector2 direction;
    private Vector2 lastMoveDirection;


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

        pMovement = GetComponent<PlayerMovement>();
        pAnimation = GetComponent<PlayerAnimation>();
        

        playerControls = new PlayerControls();

        playerControls.Gameplay.Move.performed += ReadMovement;
        playerControls.Gameplay.Move.canceled += ReadMovement;

        //playerControls.Gameplay.RangeAttack.performed += PlayerShoot;

        playerControls.Gameplay.Attack.performed += StartAttack;
        playerControls.Gameplay.FollowMouse.performed += ReadMousePosition;
    }


    public void StartAttack(InputAction.CallbackContext context)
    {
        
        pAnimation.GetAttackDirection(direction,lastMoveDirection);
        StartCoroutine(pAnimation.Attack("MeleeAttack"));
        StartCoroutine(weapon.Attack());
    }

    public void ReadMovement(InputAction.CallbackContext context)
    {
        var input = context.ReadValue<Vector2>();
        StartCoroutine(ProcessMovement(input));
    }
    public IEnumerator ProcessMovement(Vector2 input)
    {
        lastMoveDirection.x = direction.x;
        lastMoveDirection.y = direction.y;

        yield return new WaitForSeconds(0.05f);

        direction.x = input.x;
        direction.y = input.y;

        pMovement.Move(direction, lastMoveDirection);
    }

    private Vector2 GetMousePosition(InputAction.CallbackContext context)
    {
        Vector3 mousePos = context.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void ReadMousePosition(InputAction.CallbackContext context)
    {
        Vector3 mousePosition = GetMousePosition(context);

        var mouseDirection = mousePosition - transform.position;
        mouseDirection.Normalize();

        lastMoveDirection.x = mouseDirection.x;
        lastMoveDirection.y = mouseDirection.y;

        pAnimation.AnimateMovement(direction, lastMoveDirection);

    }


}
