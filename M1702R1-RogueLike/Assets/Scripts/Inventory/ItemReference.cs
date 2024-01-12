using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ItemReference : MonoBehaviour
{
    public Image Icon;
    public TMP_Text CountText;

    public UIInventaryItemSO Item { get; private set; }

    public void SetValues(UIInventaryItemSO item)
    {
        Item = item;
        Icon.sprite= item.Icon;
        UpdateCount();
    }
    public void UpdateCount()
    {
        var num = Item.Count;
       CountText.text="x"+ num;
        Debug.Log(CountText.text);
    }
}
