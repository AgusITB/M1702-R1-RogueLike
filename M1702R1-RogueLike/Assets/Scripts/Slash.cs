using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class Slash : MonoBehaviour
{

    public int damage = 5;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IDamagable obj))
        {
            Enemy enemy = (Enemy)obj;
            enemy.AnimateHit();
            enemy.TakeDamage(damage);

            if (other.TryGetComponent(out ICoinCollectible coinCollectible))
            {
                Player player = (Player)coinCollectible;
                player.CollectCoins(2); 
            }
        }
        
    }

    public void EndAnimation()
    {

        this.gameObject.SetActive(false);

    }

}
