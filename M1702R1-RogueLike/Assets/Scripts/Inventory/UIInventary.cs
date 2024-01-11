using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIInventary : MonoBehaviour
{

    [SerializeField] List<UIInventaryItem> arrayInventory;

    public List<UIInventaryItem> _Inventory;

    public static UIInventary instance;

    private void Awake()
    {
        if (instance != null) Destroy(this);
        else instance = this;


        _Inventory = new List<UIInventaryItem>();
        _Inventory = arrayInventory.OrderBy(i => i.Name).ToList();
    }
    public void AddItem(UIInventaryItem item)
    {
        if (item != null)
        {
            _Inventory.Add(item);
            arrayInventory.Add(item);
            CreateMenuInventari.instance.InstatiateElement(item);
        }
    }
    public void RemoveItem(UIInventaryItem item)
    {
        if (item != null)
        {
            _Inventory.Remove(item);
            arrayInventory.Remove(item);
        }
    }
}
