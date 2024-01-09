using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpUP : ShopItem, IConsumable
{
    void Awake()
    {
        Value = 5;
    }

    public void ConsumeItem(Player player)
    {
       player.AddMaxHP(Value);
    }
}
