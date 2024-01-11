using UnityEngine;

public class Moneda : MonoBehaviour, ICollectable
{
    int value = 5;
    public void CollectItem()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ICollector obj))
        {
            Debug.Log("Moneda recogida");
            Player player = (Player)obj;
            player.TakeItem(value);
            CollectItem();
        }
    }
}