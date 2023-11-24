using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory.UI;
using Inventory.Model;

namespace Inventory
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private InventoryPage _inventoryPage;
        [SerializeField] private InventorySO _inventoryData;

        private void Start()
        {
            PrepareUI();
            //_inventoryData.Initialize();
        }
        void PrepareUI()
        {
            _inventoryPage.InitializeInventoryUI(_inventoryData.Size);
            _inventoryPage.OnDescriptionRequested += HandleDescriptionRequest;
            _inventoryPage.OnItemActionRequested += HandleItemActionRequest;
        }

        private void HandleItemActionRequest(int itemIndex)
        {

        }

        private void HandleDescriptionRequest(int itemIndex)
        {
            InventoryItemStruct inventoryItem = _inventoryData.GetItemAt(itemIndex);
            if (inventoryItem.IsEmpty)
            {
                _inventoryPage.ResetSelection();
                return;
            }
            ItemSO item = inventoryItem.ItemSO;
            _inventoryPage.UpdateDescription(itemIndex, item.ItemImage, item.name, item.Description);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (_inventoryPage.isActiveAndEnabled == false)
                {
                    _inventoryPage.Show();
                    foreach (var item in _inventoryData.GetCurrentInventoryState())
                    {
                        _inventoryPage.UpdateData(item.Key, item.Value.ItemSO.ItemImage, item.Value.Quantity);
                    }
                }
                else
                {
                    _inventoryPage.Hide();
                }
            }
        }
    }
}