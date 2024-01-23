using TMPro;
using UnityEngine;
public class Item : MonoBehaviour
{
    public ItemSO itemSO;

    public GameObject value; 
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out ICollector obj))
        {

            if (obj.CanBuy(itemSO.price))
            {
                obj.TakeItem(itemSO, this);
                Destroy(gameObject);
            }
        }
    }
    private void Awake()
    {
        if (value != null)
        {
            TextMeshPro text = this.value.GetComponent<TextMeshPro>();
            text.text = itemSO.price.ToString();
        }
      
    }
}
