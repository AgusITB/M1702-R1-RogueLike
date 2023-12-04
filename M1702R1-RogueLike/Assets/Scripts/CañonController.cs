using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CañonController : MonoBehaviour
{
    //[SerializeField] private Transform Player;
  
    private float fireRate = 1f;  // Frecuencia de disparo en segundos
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
            timer += Time.deltaTime;
            if (timer > fireRate)
            {
                timer = 0;
                shoot();
            }

        }
    }
    void shoot()
    {
        Instantiate(bullet,bulletDirection.position,Quaternion.identity);
    }

}
