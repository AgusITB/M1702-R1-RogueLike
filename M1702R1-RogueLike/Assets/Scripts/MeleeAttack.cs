using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class MeleeAttack : Ability
{
    public GameObject meleePrefab;

    GameObject instantiatedPrefab;

    public Transform rangePosition;
    public Transform meleeParent;
    private PlayerAnimation pAnimation;


    protected override void Awake()
    {   
        base.Awake();
        pAnimation = GetComponent<PlayerAnimation>();
        Vector3 position = new (rangePosition.position.x, rangePosition.position.y );
        instantiatedPrefab = Instantiate(meleePrefab, position, Quaternion.AngleAxis(-80, meleeParent.position));
        instantiatedPrefab.transform.SetParent(meleeParent, true);
        instantiatedPrefab.SetActive(false);
    }
    public override void Cast()
    {
        StartCoroutine(pAnimation.Attack(this.AbilityName));
        pAnimation.GetAttackDirection(PlayerInputs.Instance.direction, PlayerInputs.Instance.lastMoveDirection);
        instantiatedPrefab.SetActive(true);
    }
    


}




