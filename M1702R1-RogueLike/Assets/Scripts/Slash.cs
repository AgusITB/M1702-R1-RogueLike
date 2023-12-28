using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class Slash : MonoBehaviour
{

    public int damage = 5;
    public int valor = 2;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IDamagable obj))
        {
            Enemy enemy = (Enemy)obj;
            enemy.AnimateHit();
            enemy.TakeDamage(damage);
        }
        //if(other.TryGetComponent(out ICoinCollectible coinCollectible))
        //{
        //    Player player = (Player)coinCollectible;
        //    player.CollectCoins(valor);
        //}
        if (other.CompareTag("Moneda"))
        {
            Player player = GetComponent<Player>();
            if (player != null)
            {
                player.CollectCoins(2);
            }

            Destroy(other.gameObject);

        }
    }

    public void EndAnimation()
    {

        this.gameObject.SetActive(false);

    }

}
