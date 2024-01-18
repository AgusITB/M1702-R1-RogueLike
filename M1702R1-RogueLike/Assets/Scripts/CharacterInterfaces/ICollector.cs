using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public interface ICollector
{

    public void TakeItem(ItemSO itemInfo, Item item);
    public void TakeCoin(int value);

    public bool CanBuy(int value);
}

