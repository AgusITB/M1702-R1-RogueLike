public interface ICollector
{

    public void TakeItem(ItemSO itemInfo, Item item);
    public void TakeCoin(int value);

    public bool CanBuy(int value);
}

