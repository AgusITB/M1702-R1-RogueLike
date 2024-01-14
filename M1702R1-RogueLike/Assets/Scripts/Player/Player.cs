using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : Character, IDamagable, ICollector
{
    public static Player Instance;
    public int Money { get; set; }

    private EnemyHealthBar healthBar;

    public Text coinsText;
    private int totalCoins = 0;

    //private PlayerInputs playerinput;
    //private PlayerAnimation playerAnimation;
    //private PlayerMovement playerMovement;


    public static Action<ItemSO> setItem;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
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
        // L�gica de animaci�n de golpe
    }

    public void Die()
    {
        // L�gica de muerte del jugador
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        if (currentHp <= 0) currentHp = 0;

      //  Debug.Log($"I took damage, my hp is :{currentHp}");

        healthBar.UpdateHealthBar(currentHp, maxHp);

        if (currentHp <= 0) Die();
    }
    public void UpgradeSlash(int damageAmount)
    {
        Slash.Instance.UpgradeDamage(damageAmount); 
    }
    public void HealHp(int hp)
    {
        if (currentHp+hp > maxHp) currentHp = maxHp;
        else currentHp += hp;
        healthBar.UpdateHealthBar(currentHp, maxHp);
    }
    public void AddMaxHP(int hpValue)
    {
        if (maxHp + hpValue > 50) return;
        else maxHp += hpValue;
        Debug.Log(maxHp);
    }
    public void TakeItem(ItemSO itemInfo, Item item)
    {    
        if (item.TryGetComponent(out ICollectable collectable)) collectable.CollectItem(this, item);
        else setItem.Invoke(itemInfo);
    }
    public void TakeCoin(int value)
    {
        totalCoins += value;
        UpdateCoinsText(totalCoins);
    }
    private void UpdateCoinsText(int value)
    {
        if (coinsText != null)
        {
            coinsText.text = "Monedas: " + value.ToString();
        }
    }
}
