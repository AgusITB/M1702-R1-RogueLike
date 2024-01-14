using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseSensitive : MonoBehaviour, IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler 
{
    public static event System.Action<string, string> MouseOn;
    public static event System.Action MouseOff;

    public static Action<ItemSO> onCLick;


    private ItemReference reference;
    // Start is called before the first frame update
    void Start()
    {
        reference = GetComponent<ItemReference>();
        if (reference.Item != null )
        {
            ChangeColor(Color.white);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        onCLick?.Invoke(reference.Item);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
       
        if (reference.Item != null)
        {
            ChangeColor(Color.white);
            MouseOn?.Invoke(reference.Item.Name, reference.Item.Description);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (reference.Item != null)
        {
            ChangeColor(Color.gray);
            MouseOff?.Invoke();
        }
 
    }

    private void ChangeColor(Color _color) => reference.Icon.color = _color;

}
