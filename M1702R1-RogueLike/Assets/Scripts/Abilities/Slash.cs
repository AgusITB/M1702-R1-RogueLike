using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class Slash : MonoBehaviour
{

    private int damage = 5;
    public int valor = 2;
    public static Slash Instance;

    private void Awake()
    {
     
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else Instance = this;
    }
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
    public void UpgradeDamage(int damage)
    {
        this.damage += damage;
    }

}
