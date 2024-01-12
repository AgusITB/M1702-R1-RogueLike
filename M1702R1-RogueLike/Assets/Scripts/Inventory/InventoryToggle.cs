using System;
using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    public GameObject inventoryManager;
    public static Action openInventory;
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
                   
            if(inventoryManager.activeInHierarchy) openInventory.Invoke();
        }
        else
        {
            Debug.LogWarning("El objeto InventoryManager no está asignado");
        }
    }


  
}