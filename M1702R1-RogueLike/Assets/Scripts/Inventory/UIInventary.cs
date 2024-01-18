using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class UIInventary : MonoBehaviour
{

    public List<ItemSO> _Inventory;
    
    private void OnEnable()
    {
        Player.setItem += AddItem;
        ItemSO.consumeItem += RemoveItem;
    }
    private void OnDisable()
    {
        Player.setItem -= AddItem;
        ItemSO.consumeItem -= RemoveItem;
    }

    private void Awake()
    {
        _Inventory = new List<ItemSO>();
    }
    public void AddItem(ItemSO item)
    {
        if (item != null)
        {       
            _Inventory.Add(item);    
            CreateMenuInventari.instance.UpdateELements();
        }
    }
    public void RemoveItem(ItemSO item)
    {
        if (item != null)
        {
            _Inventory.Remove(item);
            CreateMenuInventari.instance.UpdateELements();
        }
    }  

}
