using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Character, IDamagable
{
    EnemyHealthBar healthBar;
    SpriteRenderer spriteRenderer;
    Color defaultColor;
    Animator enemyAnimator;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        healthBar = GetComponentInChildren<EnemyHealthBar>();
        enemyAnimator = GetComponent<Animator>();

        maxHp = 15;
        speed = 2;
        currentHp = maxHp;
        defaultColor = spriteRenderer.color;
    }
    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        if (currentHp <= 0) currentHp = 0; 

        Debug.Log($"I took damage, my hp is :{currentHp}");

        healthBar.UpdateHealthBar(currentHp,maxHp);

        if (currentHp <= 0) Die();

    }
    public void AnimateHit()
    {
        spriteRenderer.color = Color.red;
        StartCoroutine(Flash());
        
    }
    public void Die()
    {
        enemyAnimator.SetBool("isDead", true);
        //this.gameObject.SetActive(false);
    }
    
    public IEnumerator Flash()
    {
       yield return new WaitForSeconds(0.2f);
       spriteRenderer.color = defaultColor;
    }




}
