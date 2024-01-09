using UnityEngine;

public class Moneda : MonoBehaviour, ICoinCollectible
{
    public void CollectCoins(int valor)
    {
        Debug.Log("Moneda recolectada con valor: " + valor);
        Destroy(gameObject);
    }

   
}