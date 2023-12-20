using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    public GameObject inventoryManager; // Asigna tu objeto que contiene el InventoryManager en el Inspector.

    void Start()
    {
        // Aseg�rate de que el objeto InventoryManager est� asignado.
        if (inventoryManager == null)
        {
            Debug.LogWarning("El objeto InventoryManager no est� asignado en el Inspector.");
        }
        else
        {
            // Desactiva el inventario al inicio si deseas que comience oculto.
            inventoryManager.SetActive(false);
        }
    }

    void Update()
    {
        // Presiona la tecla "I" para alternar la visibilidad del inventario.
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    void ToggleInventory()
    {
        // Aseg�rate de que el objeto InventoryManager est� asignado.
        if (inventoryManager != null)
        {
            // Activa o desactiva el inventario seg�n su estado actual.
            inventoryManager.SetActive(!inventoryManager.activeSelf);
        }
        else
        {
            Debug.LogWarning("El objeto InventoryManager no est� asignado en el Inspector.");
        }
    }
}