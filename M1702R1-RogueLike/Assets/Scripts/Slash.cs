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
    }

    public void EndAnimation()
    {

        this.gameObject.SetActive(false);

    }

}
