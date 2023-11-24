using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    PlayerAnimation pAnimation;
    public Transform meleeAim;

    Vector3 vector3; 

    private int speed = 5;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pAnimation = GetComponent<PlayerAnimation>();
    }

    public void Move(Vector2 direction, Vector2 lastDirection)
    {
        if (direction.magnitude > 0.1)
        {
            vector3 = Vector3.left * direction.x + Vector3.down * direction.y; 
        }

        if (direction.magnitude < 0.05)
        {
            rb.velocity = Vector2.zero;
            vector3 = Vector3.left * lastDirection.x + Vector3.down * lastDirection.y;
        }

        meleeAim.rotation = Quaternion.LookRotation(Vector3.forward, vector3);

        rb.velocity = new Vector2(direction.x * speed, direction.y * speed);

        pAnimation.AnimateMovement(direction,lastDirection);

    }






}
