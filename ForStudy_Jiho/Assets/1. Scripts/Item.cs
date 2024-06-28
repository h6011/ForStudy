using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    InventoryManager inventoryManager;
    [SerializeField] private string itemIdx;

    private void Start()
    {
        inventoryManager = InventoryManager.Instance;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int PlayerLayer = LayerMask.NameToLayer("Player");
        int collisionLayer = collision.gameObject.layer;

        if (collisionLayer == PlayerLayer)
        {
            bool Success = inventoryManager.GetItem(itemIdx);
            if (Success)
            {
                Destroy(gameObject);
            }
            // �κ��丮 �Ŵ������� ���� ���� �Ǵ��� Ȯ��
        }
    }



}
