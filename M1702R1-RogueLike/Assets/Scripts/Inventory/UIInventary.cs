using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class UIInventary : MonoBehaviour
{

    public List<UIInventaryItemSO> _Inventory;


    private void OnEnable()
    {
        HealingPotion.setItem += AddItem;
    }
    private void OnDisable()
    {
        HealingPotion.setItem -= AddItem;
    }

    private void Awake()
    {
        _Inventory = new List<UIInventaryItemSO>();
    }
    public void AddItem(UIInventaryItemSO item)
    {
        if (item != null)
        {
            bool therIsOne = false;

            foreach (var item2 in _Inventory)
            {
                if (item2.name == item.name) therIsOne = true;
            }
            _Inventory.Add(item);
           
            if (!therIsOne) CreateMenuInventari.instance.InstatiateElement(item);
            else CreateMenuInventari.instance.UpdateELements();

        }
    }
    public void RemoveItem(UIInventaryItemSO item)
    {
        if (item != null)
        {
            _Inventory.Remove(item);

        }
    }
}
