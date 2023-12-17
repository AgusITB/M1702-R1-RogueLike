using UnityEngine;
using UnityEngine.InputSystem;

public class ParticleController : MonoBehaviour
{
    public ParticleSystem particle; // Asigna el sistema de partículas desde el Inspector
    private bool isMousePressed = false; // Variable para verificar si el botón izquierdo del ratón está presionado

    void Update()
    {
        // Verifica si el botón izquierdo del ratón está presionado
        if (Mouse.current.leftButton.isPressed)
        {
            if (!isMousePressed) // Solo si el botón acaba de ser presionado
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
        // Establece la posición del sistema de partículas al punto de spawn del personaje
        particle.transform.position = transform.position;

        // Obtiene la dirección del mouse respecto al personaje (en 2D)
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector3 direction = (mousePosition - transform.position).normalized;

        // Calcula el ángulo en radianes
        float angle = Mathf.Atan2(direction.y, direction.x);

        // Convierte el ángulo a grados
        angle *= Mathf.Rad2Deg;

        // Aplica la rotación al sistema de partículas
        particle.transform.rotation = Quaternion.Euler(0, 0, angle);

        // Activa y reproduce las partículas
        particle.Play();
    }
}

