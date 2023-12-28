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

    protected virtual void Awake()
    {
        maxHp = 15;
        Money = 100;
    }


    public void AnimateHit()
    {

    }

    public void Die()
    {

    }

    public void TakeDamage(int damage)
    {

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
