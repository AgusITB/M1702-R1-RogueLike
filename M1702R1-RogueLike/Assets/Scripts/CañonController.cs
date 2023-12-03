using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CañonController : MonoBehaviour
{
    [SerializeField] private Transform Player;
  
    public float fireRate = 2f;  // Frecuencia de disparo en segundos
    private float nextFireTime;
    public EnergyBall bulletPrefab;

    public Transform bulletDirection;

    private void Update()
    {
        if (Time.time >= nextFireTime)
        {
            //EnergyBall g = Instantiate(bulletPrefab, bulletDirection.transform.position, bulletDirection.rotation);
            // Asegúrate de que BulletPool.Instance no es nulo
            if (BulletPool.Instance != null)
            {
                EnergyBall bullet = BulletPool.Instance.GetBullet();

                if (bullet != null)
                {
                    bullet.transform.position = transform.position;
                    bullet.SetDirection(Player.transform.position);
                    bullet.gameObject.SetActive(true);

                    nextFireTime = Time.time + 1f / fireRate;
                }
            }
            else
            {
                Debug.LogError("BulletPool.Instance is null. Make sure it's properly initialized.");
            }
        }
    }
}
