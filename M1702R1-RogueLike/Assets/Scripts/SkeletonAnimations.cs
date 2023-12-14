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

        Vector3 vec = Unit.instance.currentWaypoint;


        Vector3 dir = (this.transform.position - vec).normalized;

       
        Debug.DrawLine(vec, vec + dir * 10, Color.red, 0.2f);


        enemyAnimator.SetFloat("directionMagnitude",dir.magnitude);
        enemyAnimator.SetFloat("DirectionX", dir.x);
        enemyAnimator.SetFloat("DirectionY", dir.y);
    }



}
