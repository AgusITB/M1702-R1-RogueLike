﻿using System;
using UnityEngine;
public class Item : MonoBehaviour
{
    public ItemSO itemSO;

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out ICollector obj))
        {
            obj.TakeItem(itemSO, this);
        }
    }
}
