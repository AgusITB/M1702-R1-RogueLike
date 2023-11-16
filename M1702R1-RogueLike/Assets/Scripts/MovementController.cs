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
        playerControls.Gameplay.Move.canceled += Attack;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Animate();
    }
    private void Move(InputAction.CallbackContext context)
    {
        StartCoroutine(Release(context));
    }
    private void Attack(InputAction.CallbackContext context)
    {
        if (playerController.GetFloat("AnimMoveMagnitude") == 0)
        {
            playerController.SetFloat("AnimMoveX", playerController.GetFloat("AnimLastMoveX"));
            playerController.SetFloat("AnimMoveY", playerController.GetFloat("AnimLastMoveY"));
        }

        if (Time.time > meleeIsAllowed)
        {
            StartCoroutine(Atacar());
        }
    
       
    }



    private IEnumerator Atacar()
    {
        playerController.SetBool("MeleeAttack", true);
        yield return new WaitForSeconds(0.8f);
        playerController.SetBool("MeleeAttack", false);
        meleeIsAllowed = Time.time + meleeCD;
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
    }
    private void MovePlayer()
    {
        rigidbody.velocity = new Vector2(direction.x * speed, direction.y * speed);
    }

    private void Animate()
    {
        playerController.SetFloat("AnimMoveX", direction.x);
        playerController.SetFloat("AnimMoveY", direction.y);
        playerController.SetFloat("AnimMoveMagnitude", direction.magnitude);
        playerController.SetFloat("AnimLastMoveX", lastMoveDirection.x);
        playerController.SetFloat("AnimLastMoveY", lastMoveDirection.y);
    }

}
