using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = InventoryManager.Instance;
    }

    private bool isExistInventoryManager()
    {
        return inventoryManager != null;
    }

    private void Update()
    {
        bool IsKeyDown = Input.GetKeyDown(KeyCode.I);
        if (IsKeyDown && inventoryManager != null)
        {
            inventoryManager.InActiveInventory();
        }
    }



}
