using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float bulletSpeed = 4f;
    private Rigidbody2D rb;


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

        rb.velocity = direction * bulletSpeed;
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       //s Destroy(gameObject);   
    }
}
