using System;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public abstract class ItemSO : ScriptableObject
{
    public Sprite Icon;
    public string Name;
    public string Description;
    public int value;
    public static Action<ItemSO> consumeItem;
    public int price;

    public int ID { get; private set; }

    public int Count
    {
        get
        {
            return
                FindObjectOfType<UIInventary>()._Inventory.FindAll(x => x.ID == this.ID).Count;

        }
    }
    private void OnEnable()
    {
        MouseSensitive.onCLick += UseItem;
        ID = this.GetInstanceID();
    }
    private void OnDisable()
    {
        MouseSensitive.onCLick -= UseItem;
    }
    public void UseItem(ItemSO item)
    {
        if (!CompareID(item.ID))
        {
            return;
        }
        if (this.Count > 0)
        {
            Debug.Log("Use:" + item.Name);
            Use();

        }
    }
    protected abstract void Use();

    private bool CompareID(int ID)
    {
        return ID == this.ID;
    }
}
