using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New sword", menuName = "Items/Create damageUp")]
public class SwordSO : ItemSO
{
    public int damageAmount;

    protected override void Use()
    {
        Player.Instance.UpgradeSlash(damageAmount);
        consumeItem.Invoke(this);
    }
   
}
