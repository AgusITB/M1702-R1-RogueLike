using Assets.Scripts;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    int damage = 5;

    private SpriteRenderer weaponRenderer;

    private Collider2D weaponCollider;
    public Vector2 PointerPosition { get; set; }

    public Animator animator;


    public float delay = 0.2f;

    //private bool attackBlocked;

    private void Awake()
    {
        weaponCollider =  GetComponent<Collider2D>();
        weaponRenderer = GetComponent<SpriteRenderer>();


    
        weaponCollider.enabled = false;
    }

    public void OnTriggerEnter2D(Collider2D  other)
    {
        if(other.TryGetComponent(out IDamagable obj))
        { 
            Enemy enemy = (Enemy)obj;
            enemy.TakeDamage(damage);
        }
    }

    public void Attack()
    {

        animator.SetTrigger("Attack");
        weaponRenderer.enabled = true;
        weaponCollider.enabled = true;
        StartCoroutine(EnableHitbox());
    }

    public IEnumerator EnableHitbox()
    {
        yield return new WaitForSeconds(0.04f);

     
        weaponCollider.enabled = false;
    }

}


