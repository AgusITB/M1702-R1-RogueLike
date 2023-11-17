using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public class MovementController : MonoBehaviour
{

    private PlayerControls playerControls;
    public new Rigidbody2D rigidbody;
    private Animator playerController;
   

    private Vector2 direction = Vector2.zero;

    private Vector2 lastMoveDirection;
    private readonly int  speed = 5;

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

        playerControls.Gameplay.Move.performed += ReadInput;
        playerControls.Gameplay.Move.canceled += ReadInput;

        //playerControls.Gameplay.RangeAttack.performed += Bullet.Instance.Disparar;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Animate();
    }
    private void ReadInput(InputAction.CallbackContext context)
    {
        var input = context.ReadValue<Vector2>();

        if ((input.x == 0 && input.y == 0) && direction.x != 0 || direction.y != 0)
        {
 
            lastMoveDirection = direction.normalized;
        }

        direction.x = input.x;
        direction.y = input.y;

    }
    private void MovePlayer()
    {
        rigidbody.velocity = new Vector2(direction.x * speed, direction.y*speed);
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
