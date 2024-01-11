using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu (fileName = "New Item", menuName= "Create Item")]
public class UIInventaryItem : ScriptableObject
{
    public Sprite Icon;
    public string Name;
    public string Description;
    public int ID { get; private set; }

    public UIInventaryItem(Sprite icon, string name, string description, int iD)
    {
        Icon = icon;
        Name = name;
        Description = description;
        ID = iD;
    }
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
        ID = this.GetInstanceID();
    }
}
