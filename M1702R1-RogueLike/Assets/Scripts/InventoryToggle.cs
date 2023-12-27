using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    public GameObject inventoryManager; 

    void Start()
    {
        
        if (inventoryManager == null)
        {
            Debug.LogWarning("El objeto InventoryManager no está asignado en el Inspector.");
        }
        else
        {
            
            inventoryManager.SetActive(false);
        }
    }

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    void ToggleInventory()
    {
       
        if (inventoryManager != null)
        {
            
            inventoryManager.SetActive(!inventoryManager.activeSelf);
        }
        else
        {
            Debug.LogWarning("El objeto InventoryManager no está asignado");
        }
    }
}