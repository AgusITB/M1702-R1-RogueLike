using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class EnergyBall : MonoBehaviour
{
    private Animator animatorController;

    private float bulletSpeed = 20f;
    private Rigidbody2D rb;
    public int damage = 5;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animatorController = GetComponent<Animator>();
    }
    IEnumerator DestroyBulletAfeterTime()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
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
            AnimateExplotion();
        }
        else if (other.CompareTag("Wall"))
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
    public void SetDirection(Vector3 positionPlayer)
    {
        Vector3 direccion = (positionPlayer - transform.position).normalized;
        rb.velocity = direccion * bulletSpeed;

        float rotacion = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotacion);
    }





}
