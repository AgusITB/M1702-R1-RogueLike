using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIInventary : MonoBehaviour
{
    [SerializeField]
    UIInventaryItem[] arrayInventory;

    public List<UIInventaryItem> _Inventory { get; private set; }

    private void Awake()
    {
        _Inventory = new List<UIInventaryItem>();
        _Inventory = arrayInventory.OrderBy(i => i.Name).ToList();
    }
    public void AddItem(UIInventaryItem item)
    {
        if (item != null)
        {
            _Inventory.Add(item);
        }
    }
    public void RemoveItem(UIInventaryItem item)
    {
        if (item != null)
        {
            _Inventory.Remove(item);
        }
    }
}
