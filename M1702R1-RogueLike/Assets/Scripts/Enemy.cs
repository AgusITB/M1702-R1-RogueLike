using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Character, IDamagable
{
    EnemyHealthBar healthBar;

    private void Awake()
    {
        healthBar = GetComponentInChildren<EnemyHealthBar>();
        maxHp = 10;
        speed = 2;
        currentHp = maxHp;
    }
    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        Debug.Log($"I took damage, my hp is :{currentHp}");

        healthBar.UpdateHealthBar(currentHp,maxHp);

        if (currentHp <= 0) this.gameObject.SetActive(false);

    }



    




}
