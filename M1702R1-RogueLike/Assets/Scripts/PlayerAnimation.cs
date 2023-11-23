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

}
