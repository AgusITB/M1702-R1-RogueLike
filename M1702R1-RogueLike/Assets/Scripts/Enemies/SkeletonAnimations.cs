using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class SkeletonAnimations : MonoBehaviour
{
    Animator enemyAnimator;
    Unit me;
    SpriteRenderer spRenderer;

    private void Awake()
    {
        spRenderer = GetComponent<SpriteRenderer>();
        me = GetComponent<Unit>();
        enemyAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        //enemyAnimator.SetFloat("directionMagnitude",dir.magnitude);
        //enemyAnimator.SetFloat("DirectionX", dir.x);
        //enemyAnimator.SetFloat("DirectionY", dir.y);
    }



}
