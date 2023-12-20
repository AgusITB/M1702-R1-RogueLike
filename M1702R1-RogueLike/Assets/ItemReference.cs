using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemReference : MonoBehaviour
{
    public Image Icon;
    public Text CountText;

    public UIInventaryItem _Item { get; private set; }

    public void SetValues(UIInventaryItem item)
    {
        _Item = item;
        Icon.sprite= item.Icon;
        UpdateCount();
    }
    private void UpdateCount()
    {
        CountText.text="x"+ _Item.Count.ToString();
    }
}
