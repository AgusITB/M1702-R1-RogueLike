using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public static PlayerAnimator instance;

    private MovementController controller;
    private Animator animController;


    private void Awake()
    {
        animController = GetComponent<Animator>();
    }
    private void AnimateMovement()
    {
        animController.SetFloat("AnimMoveX", controller.direction.x);
        animController.SetFloat("AnimMoveY", controller.direction.y);

        animController.SetFloat("AnimMoveMagnitude", controller.direction.magnitude);

        animController.SetFloat("AnimLastMoveX", controller.lastMoveDirection.x);
        animController.SetFloat("AnimLastMoveY", controller.lastMoveDirection.y);

        animController.SetFloat("AttackMoveX", controller.direction.x);
        animController.SetFloat("AttackMoveY", controller.direction.y);
    }
    private void AnimateMelee()
    {
        // If the player is standing still set the attack move as parameter to the attack animation
        if (controller.direction.magnitude < 0.1)
        {
            animController.SetFloat("AttackMoveX", controller.lastMoveDirection.x);
            animController.SetFloat("AttackMoveY", controller.lastMoveDirection.y);
        }
    }
    private void AnimateRange()
    {

    }



}
