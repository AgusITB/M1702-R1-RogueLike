using UnityEngine;

public class SkeletonAnimations : MonoBehaviour
{
    Animator enemyAnimator;


    private void Awake()
    {

        enemyAnimator = GetComponent<Animator>();
    }


    public void AnimateMovement(Vector3 dir)
    {
        dir = dir.normalized;
        enemyAnimator.SetFloat("directionMagnitude", dir.magnitude);
        enemyAnimator.SetFloat("DirectionX", dir.x);
        enemyAnimator.SetFloat("DirectionY", dir.y);
    }

}
