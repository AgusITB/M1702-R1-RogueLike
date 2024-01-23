using UnityEngine;

public class CannonBullet : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    private float force=5f;

    private int damage = 5;
    public static CannonBullet instance;


    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    public void Shoot()
    {
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation + 90);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        else if (other.TryGetComponent(out IDamagable obj))
        {
            if (obj is Player)
            {
                obj.AnimateHit();
                obj.TakeDamage(damage);
            }
           
        }
    }
}
