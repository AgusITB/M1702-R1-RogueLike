using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMenuInventari : MonoBehaviour
{
    public List<ItemReference> _elements;
    [SerializeField] private List<ItemSO> _inventory;

    public static CreateMenuInventari instance;

    private void Awake()
    {
        if (instance != null) Destroy(this);
        else instance = this;
    }
    void Start()
    {
        _inventory = new List<ItemSO>();
        _inventory = FindObjectOfType<UIInventary>()._Inventory;
    }
    public void UpdateELements()
    {
        if (_inventory.Count == 0)
        {
            foreach (ItemReference item in _elements)
            {
                item.SetEmpty();

            }
        }
        for (int i = 0; i < _elements.Count; i++)
        {
            _elements[i].SetValues();
        }
    }
}
