using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemReference : MonoBehaviour
{
    public Image Icon;
    public Text CountText;

    public UIInventaryItemSO Item { get; private set; }

    public void SetValues(UIInventaryItemSO item)
    {
        Item = item;
        Icon.sprite= item.Icon;
        UpdateCount();
    }
    public void UpdateCount()
    {
       CountText.text="x"+ Item.Count.ToString();
    }
}
