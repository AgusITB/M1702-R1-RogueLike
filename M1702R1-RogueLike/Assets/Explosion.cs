using UnityEngine;

public class Explosion : MonoBehaviour
{
    int damage = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamagable obj))
        {
            Character enemy = (Character)obj;
            enemy.AnimateHit();
            enemy.TakeDamage(damage);
        }
    }
}
