using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class EnergyBall : MonoBehaviour
{

    private float bulletSpeed = 10f;
    private Rigidbody2D rb;
    public int damage = 5;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void DirectionBullet(Vector2 direction)
    {
        direction.Normalize();
        rb.velocity = direction * bulletSpeed;
        float rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IDamagable obj))
        {
            if (obj.GetType() == typeof(Player)) return;
            obj.AnimateHit();
            obj.TakeDamage(damage);           
        }
        this.gameObject.SetActive(false);
    }

}
