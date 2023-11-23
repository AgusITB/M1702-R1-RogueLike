using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerAnimator : MonoBehaviour
{
    public static PlayerAnimator instance;

    private MovementController controller;
    private Animator animController;


    private void Awake()
    {
        controller = GetComponent<MovementController>();
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
        if (controller.direction.magnitude < 0.1)
        {
            animController.SetFloat("AttackMoveX", controller.lastMoveDirection.x);
            animController.SetFloat("AttackMoveY", controller.lastMoveDirection.y);
        }
    }
    private void AnimateRange()
    {

    }


    private IEnumerator AttackCoolDownHandler(string attackType , float cooldown)
    {
        animController.SetBool(attackType, true);

        yield return new WaitForSeconds(cooldown);

        animController.SetBool(attackType, false);
    }

}
