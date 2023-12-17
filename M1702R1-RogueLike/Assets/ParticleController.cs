using UnityEngine;
using UnityEngine.InputSystem;

public class ParticleController : MonoBehaviour
{
    public ParticleSystem particle; // Asigna el sistema de part�culas desde el Inspector
    private bool isMousePressed = false; // Variable para verificar si el bot�n izquierdo del rat�n est� presionado

    void Update()
    {
        // Verifica si el bot�n izquierdo del rat�n est� presionado
        if (Mouse.current.leftButton.isPressed)
        {
            if (!isMousePressed) // Solo si el bot�n acaba de ser presionado
            {
                ActivateParticles();
            }
            isMousePressed = true;
        }
        else
        {
            isMousePressed = false;
            particle.Stop();
        }
    }

    void ActivateParticles()
    {
        // Establece la posici�n del sistema de part�culas al punto de spawn del personaje
        particle.transform.position = transform.position;

        // Obtiene la direcci�n del mouse respecto al personaje (en 2D)
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector3 direction = (mousePosition - transform.position).normalized;

        // Calcula el �ngulo en radianes
        float angle = Mathf.Atan2(direction.y, direction.x);

        // Convierte el �ngulo a grados
        angle *= Mathf.Rad2Deg;

        // Aplica la rotaci�n al sistema de part�culas
        particle.transform.rotation = Quaternion.Euler(0, 0, angle);

        // Activa y reproduce las part�culas
        particle.Play();
    }
}

