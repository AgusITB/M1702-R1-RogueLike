using UnityEngine;

public class MovementBossFinal : Enemy
{
    int damage = 15;
    private Vector2 movementDirection;
    public NextLevel nextLevel;
    protected override void Awake()
    {
        base.Awake();
        nextLevel.gameObject.SetActive(false);
        maxHp = 50;
        currentHp = maxHp;
        speed = 5;
    }
    void Start()
    {   
        // Establecer una dirección de movimiento inicial aleatoria
        movementDirection = Random.insideUnitCircle.normalized;
    }

    void Update()
    {
        
        Vector2 movement = movementDirection * speed * Time.deltaTime;
        transform.Translate(movement);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {      
        if (collision.gameObject.CompareTag("Wall"))
        {
            ReflectMovement(collision.contacts[0].normal);
        }
        else if (collision.gameObject.TryGetComponent(out IDamagable player))
        {
            if (player is Player)
            {
                player.AnimateHit();
                player.TakeDamage(damage);
            }

        }
    }
    void ReflectMovement(Vector2 normal)
    {
        // Reflejar el vector de dirección respecto a la normal
        movementDirection = Vector2.Reflect(movementDirection, normal).normalized;
        FlipHorizontal();
    }
    void FlipHorizontal()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1f;
        transform.localScale = scale;
    }
    public override void Die()
    {
        nextLevel.gameObject.SetActive(true);
        base.Die();
    }
}
