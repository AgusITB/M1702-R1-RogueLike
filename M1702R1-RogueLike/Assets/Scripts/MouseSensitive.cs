using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseSensitive : MonoBehaviour, IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler 
{
    public static event System.Action<string, string> MouseOn;
    public static event System.Action MouseOff;
    private ItemReference reference;
    // Start is called before the first frame update
    void Start()
    {
        reference = GetComponent<ItemReference>();
        ChangeColor(Color.gray);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
       
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ChangeColor(Color.white);
        MouseOn?.Invoke(reference._Item.Name, reference._Item.Description);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ChangeColor(Color.gray);
        MouseOff?.Invoke();
    }

    private void ChangeColor(Color _color) => reference.Icon.color = _color;

}
