using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{

    private PlayerControls playerControls;

    PlayerMovement pMovement;
   

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
   

        playerControls = new PlayerControls();

        playerControls.Gameplay.Move.performed += ReadMovement;
        playerControls.Gameplay.Move.canceled += ReadMovement;

        //playerControls.Gameplay.RangeAttack.performed += PlayerShoot;

        //playerControls.Gameplay.Attack.performed += Attack;
        //playerControls.Gameplay.FollowMouse.performed += Face;
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
    public void ReadMovement(InputAction.CallbackContext context)
    {
        var input = context.ReadValue<Vector2>();
        StartCoroutine(ProcessMovement(input));
    }
}
