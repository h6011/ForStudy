using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    InventoryManager inventoryManager;
    [SerializeField] private string itemIdx;

    private void Awake()
    {
        inventoryManager = InventoryManager.Instance;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int PlayerLayer = LayerMask.NameToLayer("Player");
        int collisionLayer = collision.gameObject.layer;

        if (collisionLayer == PlayerLayer)
        {
            inventoryManager.GetItem(itemIdx);
            // 인벤토리 매니저에게 내가 습득 되는지 확인
        }
    }



}
