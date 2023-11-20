using System.Collections;
using System.Net.WebSockets;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class MovementController : MonoBehaviour
{

    private PlayerControls playerControls;
 
    public new Rigidbody2D rigidbody;
    
    
    private Animator playerController;
    [SerializeField]private GameObject bullet;
    [SerializeField]private Transform bulletDirection;
    private bool canShoot = true;
    private Camera main;


    private Vector2 direction = Vector2.zero;
    public static MovementController player;

    public WeaponParent weaponParent;

    public Transform Aim;

    private Vector2 direction = Vector2.zero;
    private Vector2 lastMoveDirection;

    private readonly int speed = 5;

    private readonly float meleeCD = .5f;

    private bool meleeIsAllowed = true;



   

    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }
    private void Start()
    {
        main = Camera.main;
        playerControls.Gameplay.RangeAttack.performed += _ => PlayerShoot();

    }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerController = GetComponent<Animator>();
        weaponParent = GetComponentInChildren<WeaponParent>();

        playerControls = new PlayerControls();

        playerControls.Gameplay.Move.performed += ReadInput;
        playerControls.Gameplay.Move.canceled += ReadInput;
        playerControls.Gameplay.Move.performed += Move;
        playerControls.Gameplay.Move.canceled += Move;
        playerControls.Gameplay.Attack.performed += Attack;
        playerControls.Gameplay.FollowMouse.performed += Face;
    }


    private void Move(InputAction.CallbackContext context)
    {
        MovePlayer();
        Animate();
        MousePosition();
        StartCoroutine(MoveParameters(context));
    }
    private IEnumerator MoveParameters(InputAction.CallbackContext context)
    {
        var input = context.ReadValue<Vector2>();

        lastMoveDirection.x = direction.x;
        lastMoveDirection.y = direction.y;

        if (direction.magnitude < 0.05)
        {
            rigidbody.velocity = Vector2.zero;
            Aim.rotation = Quaternion.LookRotation(Vector3.back, direction * -1);
        }

        yield return new WaitForSeconds(0.05f);

        direction.x = input.x;
        direction.y = input.y;

        Animate();
        MovePlayer();
    }

    private void Attack(InputAction.CallbackContext context)
    {
     
        if (meleeIsAllowed)
        {
            meleeIsAllowed = true;
            StartCoroutine(AttackAnimation());
        }
    
    }
    private IEnumerator AttackAnimation()
    {
        meleeIsAllowed = false;
        weaponParent.Attack();

        playerController.SetBool("MeleeAttack", true);

        yield return new WaitForSeconds(meleeCD);

        playerController.SetBool("MeleeAttack", false);
        meleeIsAllowed = true;
        Animate();
    }


    // Look at the direction of the mouse ON IDLE
    private void Face(InputAction.CallbackContext context)
    {
        Vector3 worldMousePosition = GetMousePosition();

        var vectorDir = worldMousePosition - rigidbody.transform.position;
        vectorDir.Normalize();

        lastMoveDirection.x = vectorDir.x;
        lastMoveDirection.y = vectorDir.y;
        if (direction.magnitude < 0.1) Aim.rotation = Quaternion.LookRotation(Vector3.back, vectorDir * -1);

        Animate();
    }


    private Vector2 GetMousePosition()
    {
        Vector3 mousePos = playerControls.Gameplay.FollowMouse.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
    private void MovePlayer()
    {

        if (direction.magnitude < 0.1) Aim.rotation = Quaternion.LookRotation(Vector3.back, lastMoveDirection * -1);
        else Aim.rotation = Quaternion.LookRotation(Vector3.back, direction * -1);

        rigidbody.velocity = new Vector2(direction.x * speed, direction.y * speed);
    }
    private void PlayerShoot()
    {
        if (!canShoot) return;
 
        Vector2 mousePosition = playerControls.Gameplay.MousePosition.ReadValue<Vector2>();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        GameObject g = Instantiate(bullet, bulletDirection.position, bulletDirection.rotation);
        Debug.Log("Se ha activado la bala");
        g.SetActive(true);
        StartCoroutine(CanShoot());
    
    }
    IEnumerator CanShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(0.5f);
        canShoot = true;
    }

    private void Animate()
    {
        playerController.SetFloat("AnimMoveX", direction.x);
        playerController.SetFloat("AnimMoveY", direction.y);

        playerController.SetFloat("AnimMoveMagnitude", direction.magnitude);

        playerController.SetFloat("AnimLastMoveX", lastMoveDirection.x);
        playerController.SetFloat("AnimLastMoveY", lastMoveDirection.y);

        playerController.SetFloat("AttackMoveX", direction.x);
        playerController.SetFloat("AttackMoveY", direction.y);

        // If the player is standing still set the attack move as parameter to the attack animation
        if (direction.magnitude < 0.1)
        {
            playerController.SetFloat("AttackMoveX", lastMoveDirection.x);
            playerController.SetFloat("AttackMoveY", lastMoveDirection.y);
        }


    }
    private void MousePosition()
    {
        //Rotation
        Vector2 mouseScreenPosition = playerControls.Gameplay.MousePosition.ReadValue<Vector2>();
        Vector3 mouseWorldPosition = main.ScreenToWorldPoint(mouseScreenPosition);
        Vector3 targetDirection = mouseWorldPosition - transform.position;
        float angle= Mathf.Atan2(targetDirection.y, targetDirection.x);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

}
