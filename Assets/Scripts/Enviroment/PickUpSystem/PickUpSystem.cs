using Inventory.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PickUpSystem : MonoBehaviour
{
    [SerializeField]
    private InventorySO inventoryData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Fruit fruit = collision.GetComponent<Fruit>();
        if (fruit != null)
        {
            if (fruit.CanPickUp)
            {
                int reminder = inventoryData.AddItem(fruit.InventoryItem, fruit.Quantity);
                if (reminder == 0)
                    fruit.DestroyFruit();
                else
                    fruit.Quantity = reminder;
            }
        }
    }
}
