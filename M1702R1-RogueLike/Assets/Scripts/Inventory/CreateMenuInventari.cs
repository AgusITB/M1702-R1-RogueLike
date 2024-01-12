using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMenuInventari : MonoBehaviour
{
    public ItemReference _element;
    [SerializeField] private List<UIInventaryItemSO> _inventory;

    public static CreateMenuInventari instance;


    private void OnEnable()
    {
        InventoryToggle.openInventory += UpdateELements; 
    }

    private void OnDisable()
    {
        InventoryToggle.openInventory -= UpdateELements;
    }

    private void Awake()
    {
        if (instance != null) Destroy(this);
        else instance = this;
    }
    void Start()
    {
        _inventory = new List<UIInventaryItemSO>();
        _inventory = FindObjectOfType<UIInventary>()._Inventory;
        InstantiateElements();
    }
    private void InstantiateElements()
    {
        for (int i = 0; i < _inventory.Count; i++)
        {
            if (IsRepeated(i))
                continue;
            (Instantiate(_element, transform) as ItemReference).SetValues(_inventory[i]);
        }
    }
    public void UpdateELements()
    {
        for (int i = 0; i < _inventory.Count; i++)
        {
            (_element as ItemReference).SetValues(_inventory[i]);
        }
    }
    public void InstatiateElement(UIInventaryItemSO item)
    {
        (Instantiate(_element, transform) as ItemReference).SetValues(item);
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
