using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

class HealingPotion : Item
{
    public static Action<UIInventaryItemSO> setItem;
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player obj))
        {
            setItem.Invoke(this.itemSO);
        }
    }


}

