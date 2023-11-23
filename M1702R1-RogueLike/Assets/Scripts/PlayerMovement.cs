using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    PlayerAnimation pAnimation;


    private int speed = 5;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pAnimation = GetComponent<PlayerAnimation>();
    }

    public void Move(Vector2 direction, Vector2 lastDirection)
    {
        if (direction.magnitude < 0.05)
        {
            rb.velocity = Vector2.zero;
        }
        rb.velocity = new Vector2(direction.x * speed, direction.y * speed);

        pAnimation.AnimateMovement(direction,lastDirection);
    }






}
