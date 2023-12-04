using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CañonController : MonoBehaviour
{
    //[SerializeField] private Transform Player;
  
    private float fireRate = 2f;  // Frecuencia de disparo en segundos
    //private float nextFireTime;

    public GameObject bullet;
    public Transform bulletDirection;
    private float timer;
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        //if (Time.time >= nextFireTime)
        //{
        //    //EnergyBall g = Instantiate(bulletPrefab, bulletDirection.transform.position, bulletDirection.rotation);
        //    // Asegúrate de que BulletPool.Instance no es nulo
        //    if (BulletPool.Instance != null)
        //    {
        //        EnergyBall bullet = BulletPool.Instance.GetBullet();

        //        if (bullet != null)
        //        {
        //            bullet.transform.position = transform.position;
        //            bullet.SetDirection(Player.transform.position);
        //            bullet.gameObject.SetActive(true);

        //            nextFireTime = Time.time + 1f / fireRate;
        //        }
        //    }
        //    else
        //    {
        //        Debug.LogError("BulletPool.Instance is null. Make sure it's properly initialized.");
        //    }
        //}

        float distance= Vector2.Distance(transform.position,player.transform.position);
        Debug.Log(distance);

        if(distance < 10)
        {
            RotateTowards();
            timer += Time.deltaTime;
            if (timer > fireRate)
            {
                timer = 0;
                shoot();
            }
        }
    }
    private void RotateTowards()
    {
        var playerPos = player.transform.position;
        var position = transform.position;

        float angle = Mathf.Atan2(playerPos.y - position.y, playerPos.x - position.x) * Mathf.Rad2Deg - 90f;

        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);

        transform.rotation = targetRotation;
    }
    public void shoot()
    {
        Instantiate(bullet,bulletDirection.position,Quaternion.identity);
    }

}
