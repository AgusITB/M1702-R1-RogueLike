using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public abstract class Item : MonoBehaviour
{
    public UIInventaryItemSO itemSO;
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
    }
}
