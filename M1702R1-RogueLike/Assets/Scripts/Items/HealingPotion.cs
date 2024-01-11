using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

class HealingPotion : Item
{

    public UIInventaryItem potionSO;

    void Awake()
    {
       
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Someone is trying to buy me");
        if (collision.TryGetComponent(out Player obj))
        {
            UIInventary.instance.AddItem(potionSO);
        }
    }

}

