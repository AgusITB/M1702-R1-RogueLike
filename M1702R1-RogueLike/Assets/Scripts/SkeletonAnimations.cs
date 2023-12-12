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

        Vector3 vec = new Vector3(me.target.position.x, me.target.position.y, me.target.position.z);
    
        Vector3 dir = (this.transform.position - vec).normalized;

       
        Debug.DrawLine(vec, vec + dir * 10, Color.red, 0.2f);


        enemyAnimator.SetFloat("directionMagnitude",dir.magnitude);
        enemyAnimator.SetFloat("DirectionX", me.target.position.x);
        enemyAnimator.SetFloat("DirectionY", me.target.position.y);
    }



}
