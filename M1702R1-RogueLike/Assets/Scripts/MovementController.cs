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

    public static MovementController Instance;

    public Animator animController;


    //Private Components
    private PlayerControls playerControls;
    private Rigidbody2D rb;  
    
    private Camera main;

    //Private GameObjects
    public WeaponParent weaponParent;
    public static MovementController player;

    //Private Variables
    public Vector2 direction = Vector2.zero;
    public Vector2 lastMoveDirection;

    [SerializeField]private Bullet bullet;
    [SerializeField]private Transform bulletDirection;

    private bool canShoot = true;
    

    public Transform Aim;

    

    private readonly int speed = 5;

    private readonly float meleeCD = .5f;

    private bool meleeIsAllowed = true;
    private bool rangedIsAllowed = true;




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
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animController = GetComponent<Animator>();
        weaponParent = GetComponentInChildren<WeaponParent>();

        playerControls = new PlayerControls();

        playerControls.Gameplay.Move.performed += Move;
        playerControls.Gameplay.Move.canceled += Move;


        playerControls.Gameplay.RangeAttack.performed += PlayerShoot;

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
            rb.velocity = Vector2.zero;
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

        animController.SetBool("MeleeAttack", true);

        yield return new WaitForSeconds(meleeCD);

        animController.SetBool("MeleeAttack", false);
        meleeIsAllowed = true;
        Animate();
    }

    private IEnumerator RangedAttackAnimation()
    {
        rangedIsAllowed = false;
        
        animController.SetBool("RangeAttack", true);

        yield return new WaitForSeconds(0.583f);

        animController.SetBool("RangeAttack", false);
        rangedIsAllowed = true;
    }


    // Look at the direction of the mouse ON IDLE
    private void Face(InputAction.CallbackContext context)
    {
        Vector3 worldMousePosition = GetMousePosition();

        var vectorDir = worldMousePosition - rb.transform.position;
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

        rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
    }
    private void PlayerShoot(InputAction.CallbackContext context)
    {
        if (!canShoot) return;

        
        Vector2 mousePosition = playerControls.Gameplay.FollowMouse.ReadValue<Vector2>();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Bullet g = Instantiate(bullet, bulletDirection.position, bulletDirection.rotation);

        Debug.Log("Se ha activado la bala");

        StartCoroutine(RangedAttackAnimation());

        g.gameObject.SetActive(true);
        g.DirectionBullet(mousePosition);
        StartCoroutine(CanShoot());
    
    }
    IEnumerator CanShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(2f);
        canShoot = true;
    }

    private void Animate()
    {
        animController.SetFloat("AnimMoveX", direction.x);
        animController.SetFloat("AnimMoveY", direction.y);

        animController.SetFloat("AnimMoveMagnitude", direction.magnitude);

        animController.SetFloat("AnimLastMoveX", lastMoveDirection.x);
        animController.SetFloat("AnimLastMoveY", lastMoveDirection.y);

        animController.SetFloat("AttackMoveX", direction.x);
        animController.SetFloat("AttackMoveY", direction.y);

        // If the player is standing still set the attack move as parameter to the attack animation
        if (direction.magnitude < 0.1)
        {
            animController.SetFloat("AttackMoveX", lastMoveDirection.x);
            animController.SetFloat("AttackMoveY", lastMoveDirection.y);
        }


    }
    private void MousePosition()
    {
        //Rotation
        Vector2 mouseScreenPosition = playerControls.Gameplay.FollowMouse.ReadValue<Vector2>();
        Vector3 mouseWorldPosition = main.ScreenToWorldPoint(mouseScreenPosition);
        Vector3 targetDirection = mouseWorldPosition - transform.position;
        float angle= Mathf.Atan2(targetDirection.y, targetDirection.x);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

}
