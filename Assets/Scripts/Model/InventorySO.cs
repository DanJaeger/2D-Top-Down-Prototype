using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Inventory.Model
{
    [CreateAssetMenu]
    public class InventorySO : ScriptableObject
    {
        [SerializeField] private List<InventoryItemStruct> _inventoryItems;
        [field: SerializeField] public int Size { get; private set; } = 10;

        public void Initialize()
        {
            _inventoryItems = new List<InventoryItemStruct>();
            for (int i = 0; i < Size; i++)
            {
                _inventoryItems.Add(InventoryItemStruct.GetEmptyItem());
            }
        }
        public void Additem(ItemSO item, int quantity)
        {
            for (int i = 0; i < _inventoryItems.Count; i++)
            {
                if (_inventoryItems[i].IsEmpty)
                {
                    _inventoryItems[i] = new InventoryItemStruct
                    {
                        ItemSO = item,
                        Quantity = quantity
                    };
                }
            }
        }
        public Dictionary<int, InventoryItemStruct> GetCurrentInventoryState()
        {
            Dictionary<int, InventoryItemStruct> returnValue = new Dictionary<int, InventoryItemStruct>();

            for (int i = 0; i < _inventoryItems.Count; i++)
            {
                if (_inventoryItems[i].IsEmpty)
                    continue;
                returnValue[i] = _inventoryItems[i];
            }

            return returnValue;
        }

        public InventoryItemStruct GetItemAt(int itemIndex)
        {
            return _inventoryItems[itemIndex];
        }
    }
    [Serializable]
    public struct InventoryItemStruct
    {
        public int Quantity;
        public ItemSO ItemSO;
        public bool IsEmpty => ItemSO == null;

        public InventoryItemStruct ChangeQuantity(int newQuantity)
        {
            return new InventoryItemStruct
            {
                ItemSO = this.ItemSO,
                Quantity = newQuantity
            };
        }
        public static InventoryItemStruct GetEmptyItem() => new InventoryItemStruct
        {
            ItemSO = null,
            Quantity = 0,
        };
    }
}

