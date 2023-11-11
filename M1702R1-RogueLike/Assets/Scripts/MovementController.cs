using UnityEngine;
using UnityEngine.InputSystem;


public class MovementController : MonoBehaviour
{

    private PlayerControls playerControls;
    public new Rigidbody2D rigidbody;
    private Vector3 direction = Vector2.zero;
    private int speed = 5;

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
        rigidbody= GetComponent<Rigidbody2D>();

        playerControls = new PlayerControls();

        playerControls.Gameplay.Move.performed += ReadInput;
        playerControls.Gameplay.Move.canceled += ReadInput;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
    private void ReadInput(InputAction.CallbackContext context)
    {
        var input = context.ReadValue<Vector2>();
        direction.x = input.x;
        direction.y = input.y;       
    }
    private void MovePlayer()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

}
