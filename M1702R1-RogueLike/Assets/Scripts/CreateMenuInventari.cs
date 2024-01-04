using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMenuInventari : MonoBehaviour
{
    public ItemReference _element;
    private List<UIInventaryItem> _inventory;

    void Start()
    {
        _inventory = new List<UIInventaryItem>();
        _inventory = FindObjectOfType<UIInventary>()._Inventory;
        InstantiateElements();
    }
    private void InstantiateElements()
    {
        for(int i=0;i< _inventory.Count;i++)
        {
            if (IsRepeated(i))
                continue;
            (Instantiate(_element, transform) as ItemReference).SetValues(_inventory[i]);
        }
    }

    bool IsRepeated(int i)
    {
        if (i == 0)
        {
            return false;
        }
        return _inventory[i].ID == _inventory[i - 1].ID;
    }

   
}