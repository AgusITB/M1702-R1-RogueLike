using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ItemReference : MonoBehaviour
{
    public Image Icon;
    public TMP_Text CountText;

    public ItemSO Item;

    public static Action emptyReference;

    public void SetValues()
    {
        var num = Item.Count;
        CountText.text = "x" + num;
    }
    public void SetEmpty()
    {
        var num = 0;
        CountText.text = "x" + num;
    }
}
