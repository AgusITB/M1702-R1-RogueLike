using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class Bullet : MonoBehaviour
{

    private float bulletSpeed = 10f;
    private Rigidbody2D rb;
    private int damage = 5;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    IEnumerator DestroyBulletAfeterTime()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
    private void Update()
    {
       
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
            obj.AnimateHit();
            obj.TakeDamage(damage);
            this.gameObject.SetActive(false);
        }
    }
}
