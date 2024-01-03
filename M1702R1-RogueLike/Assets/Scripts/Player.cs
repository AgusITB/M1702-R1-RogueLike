using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Character, IDamagable
{
    public int Money { get; set; }

    private EnemyHealthBar healthBar;

    protected virtual void Awake()
    {
        maxHp = 100;
        Money = 100;
        currentHp = maxHp;
        healthBar = GameObject.FindGameObjectWithTag("playerHealthBar").GetComponent<EnemyHealthBar>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           TakeDamage(25);
        }
    }
    public void AnimateHit()
    {

    }

    public void Die()
    {

    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        if (currentHp <= 0) currentHp = 0;

        Debug.Log($"I took damage, my hp is :{currentHp}");

        healthBar.UpdateHealthBar(currentHp, maxHp);

        if (currentHp <= 0) Die();

    }
    public void AddMaxHP(int hpValue)
    {
        if (maxHp + hpValue > 50)
        {
            return;
        }
        else maxHp += hpValue;
        Debug.Log(maxHp);
    }
    public void BuyItem(int value, ShopItem item)
    {

        if (item is IConsumable consumable)
        {
            consumable.ConsumeItem(this);
            Money -= value;
            item.gameObject.SetActive(false);
        }
        else
        {
            throw new NotImplementedException();
        }
    }
}
