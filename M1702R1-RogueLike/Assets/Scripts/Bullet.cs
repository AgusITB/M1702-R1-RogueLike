using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float speed = 4f;

    private void Start()
    {
        
    }
    IEnumerator DestroyBulletAfeterTime()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
    private void Update()
    {
        transform.Translate( transform.up * speed* Time.deltaTime,Space.World);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);   
    }
}
