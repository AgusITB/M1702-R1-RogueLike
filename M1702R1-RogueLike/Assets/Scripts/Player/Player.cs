using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : Character, ICollector
{
    public static Player Instance;
    public int Money { get; set; }

    public Text coinsText;
    private int totalCoins = 0;

    public static Action<ItemSO> setItem;

    public GameObject gotHitScreen;


    protected override void Awake()
    {
        base.Awake();
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        maxHp = 100;
        Money = 100;
        currentHp = maxHp;
        healthBar = GameObject.FindGameObjectWithTag("playerHealthBar").GetComponent<EnemyHealthBar>();
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
        if (item.TryGetComponent(out ICollectable collectable))
        {
            collectable.CollectItem(this, item);
        }
        else
        {
            totalCoins -= itemInfo.value;
            UpdateCoinsText(totalCoins);
            setItem.Invoke(itemInfo);
        }
    }
    public bool CanBuy(int price)
    {
        return totalCoins >= price;
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

    public override void AnimateHit()
    {
        StopCoroutine(FlashScreen());
        base.AnimateHit();
        StartCoroutine(FlashScreen());
    }
    private IEnumerator FlashScreen()
    {
        var color = gotHitScreen.GetComponent<Image>().color;
        color.a = 0.3f;
        gotHitScreen.GetComponent<Image>().color = color;
        yield return new WaitForSeconds(0.2f);
        color.a = 0f;
        gotHitScreen.GetComponent<Image>().color = color;
    }

}
