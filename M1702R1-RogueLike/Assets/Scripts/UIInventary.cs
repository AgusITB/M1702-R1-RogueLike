using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventary : MonoBehaviour
{
    [SerializeField]
    private UIInventaryItem itemprebab;

    [SerializeField]
    private RectTransform panel;


    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }


}
