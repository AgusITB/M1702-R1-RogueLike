using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class Coin : Item, ICollectable
{
    public void CollectItem(ICollector collector, Item item)
    {
        collector.TakeCoin(itemSO.value);
        Destroy(item.gameObject);
    }
}

