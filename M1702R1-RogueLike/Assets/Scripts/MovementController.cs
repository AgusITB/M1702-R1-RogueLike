using System.Collections;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class MovementController : MonoBehaviour
{

    private PlayerControls playerControls;
    public new Rigidbody2D rigidbody;
    private Animator playerController;

    private Vector2 direction = Vector2.zero;

    private Vector2 lastMoveDirection;
    private readonly int speed = 5;
    private float meleeCD = 1.5f;
    private float meleeIsAllowed;



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
        rigidbody = GetComponent<Rigidbody2D>();
        playerController = GetComponent<Animator>();

        playerControls = new PlayerControls();

        playerControls.Gameplay.Move.performed += Move;
        playerControls.Gameplay.Move.canceled += Move;
        playerControls.Gameplay.Attack.performed += Attack;

    }

    // Update is called once per frame

    private void Move(InputAction.CallbackContext context)
    {
        StartCoroutine(Release(context));
    }
    private void Attack(InputAction.CallbackContext context)
    {
        if (Time.time > meleeIsAllowed)
        {
            StartCoroutine(AnimAtack());
        }
    }

    private IEnumerator AnimAtack()
    {
        playerController.SetBool("MeleeAttack", true);
        yield return new WaitForSeconds(0.8f);
        playerController.SetBool("MeleeAttack", false);
        meleeIsAllowed = Time.time + meleeCD;
        Animate();
    }

    private IEnumerator Release(InputAction.CallbackContext context)
    {
        var input = context.ReadValue<Vector2>();

        lastMoveDirection.x = direction.x;
        lastMoveDirection.y = direction.y;

        if (direction.magnitude < 0.05) rigidbody.velocity = Vector2.zero;

        yield return new WaitForSeconds(0.05f);

        direction.x = input.x;
        direction.y = input.y;
        MovePlayer();
        Animate();
    }
    private void MovePlayer()
    {
        rigidbody.velocity = new Vector2(direction.x * speed, direction.y * speed);
    }

    private void Animate()
    {
        playerController.SetFloat("AnimMoveX", direction.x);
        playerController.SetFloat("AnimMoveY", direction.y);

        playerController.SetFloat("AttackMoveX", direction.x);
        playerController.SetFloat("AttackMoveY", direction.y);

        if (direction.magnitude < 0.1)
        {
            playerController.SetFloat("AttackMoveX", lastMoveDirection.x);
            playerController.SetFloat("AttackMoveY", lastMoveDirection.y);
        }

        playerController.SetFloat("AnimMoveMagnitude", direction.magnitude);
        playerController.SetFloat("AnimLastMoveX", lastMoveDirection.x);
        playerController.SetFloat("AnimLastMoveY", lastMoveDirection.y);
    }

}
