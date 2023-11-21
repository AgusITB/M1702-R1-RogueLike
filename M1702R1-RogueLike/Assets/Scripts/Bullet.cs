using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class Bullet : MonoBehaviour
{
    private Animator animatorController;

    private float bulletSpeed = 10f;
    private Rigidbody2D rb;
    private int damage = 5;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animatorController = GetComponent<Animator>();
    }
    IEnumerator DestroyBulletAfeterTime()
    {
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
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
            Enemy enemy = (Enemy)obj;
            enemy.AnimateHit();
            enemy.TakeDamage(damage);
            AnimateExplotion();
        } else if (other.CompareTag("Wall"))
        {
            AnimateExplotion();

        }
    }
    private void AnimateExplotion()
    {
        this.animatorController.SetBool("Exploded", true);
        rb.velocity = Vector3.zero;
        StartCoroutine(DestroyBulletAfeterTime());
    }
}
