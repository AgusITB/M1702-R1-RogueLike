using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBossFinal : MonoBehaviour
{
    public float speed = 5f; 

    private Vector2 movementDirection;

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
}
