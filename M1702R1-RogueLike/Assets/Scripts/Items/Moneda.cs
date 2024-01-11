using UnityEngine;

public class Moneda : MonoBehaviour, ICollectable
{
    int value = 5;
    public void CollectItem()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ICollector obj))
        {
            Player player = (Player)obj;
            player.TakeItem(value);
            CollectItem();
        }
    }
}
