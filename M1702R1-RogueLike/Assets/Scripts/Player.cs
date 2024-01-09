using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : Character, IDamagable, ICoinCollectible
{

    public int Money { get; set; }

    private EnemyHealthBar healthBar;

    public Text coinsText;
    private int totalCoins = 0;

    private PlayerInputs playerinput;
    private PlayerAnimation playerAnimation;
    private PlayerMovement playerMovement;

    private void Awake()
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
        // L�gica para reducir la salud del jugador
        }
    }

    public void CollectCoins(int coinValue)
    {
        totalCoins += coinValue;
        Debug.Log("Recogidas " + coinValue + " puntos. Total: " + totalCoins + " monedas ");
        UpdateCoinsText(totalCoins);
    }

    private void UpdateCoinsText(int value)
    {
        if (coinsText != null)
        {
            coinsText.text = " + " + value.ToString();
        }
    }
}
