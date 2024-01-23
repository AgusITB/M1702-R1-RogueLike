public class Coin : Item, ICollectable
{
    public void CollectItem(ICollector collector, Item item)
    {
        collector.TakeCoin(itemSO.value);
        Destroy(item.gameObject);
    }
}

