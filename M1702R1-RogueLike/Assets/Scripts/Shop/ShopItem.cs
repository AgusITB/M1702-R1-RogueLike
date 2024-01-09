using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShopItem : MonoBehaviour
{

    [SerializeField] private string itemDescription = "New Item Description";
    protected int Value { get; set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Someone is trying to buy me");
        if (collision.TryGetComponent(out Player obj))
        {
            Debug.Log("A player is trying to buy me");
            if (obj.Money >= Value)
                obj.BuyItem(Value, this);
        }
    }

}
