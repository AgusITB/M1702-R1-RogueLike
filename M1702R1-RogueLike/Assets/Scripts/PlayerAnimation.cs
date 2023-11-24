using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator animator;


    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }


    public void AnimateMovement(Vector2 direction, Vector2 lastDirection)
    {
        animator.SetFloat("AnimMoveX", direction.x);
        animator.SetFloat("AnimMoveY", direction.y);

        animator.SetFloat("AnimMoveMagnitude", direction.magnitude);

        animator.SetFloat("AnimLastMoveX", lastDirection.x);
        animator.SetFloat("AnimLastMoveY", lastDirection.y);

    }

    public void GetAttackDirection(Vector2 direction, Vector2 lastDirection)
    {
        animator.SetFloat("AttackMoveX", direction.x);
        animator.SetFloat("AttackMoveY", direction.y);

        // If the player is standing still set the attack move as parameter to the attack animation
        if (direction.magnitude < 0.1)
        {
            animator.SetFloat("AttackMoveX", lastDirection.x);
            animator.SetFloat("AttackMoveY", lastDirection.y);
        }
    }
    public IEnumerator Attack(string attackType)
    {
        animator.SetBool(attackType, true);
        yield return new WaitForSeconds(0.583f);
        animator.SetBool(attackType, false);
    }


}
