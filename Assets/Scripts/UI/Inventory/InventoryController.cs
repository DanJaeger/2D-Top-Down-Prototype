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
        [SerializeField] private UIInventoryPage _inventoryPage;
        [SerializeField] private InventorySO _inventoryData;
        public List<InventoryItems> initialItems = new List<InventoryItems>();
        private void Start()
        {
            PrepareUI();
            PrepareInventoryData();
        }
        #region Prepare UI
        void PrepareUI()
        {
            _inventoryPage.InitializeInventoryUI(_inventoryData.Size);
            _inventoryPage.OnDescriptionRequested += HandleDescriptionRequest;
            _inventoryPage.OnItemActionRequested += HandleItemActionRequest;
        }
        private void PrepareInventoryData()
        {
            _inventoryData.Initialize();
            _inventoryData.OnInventoryUpdated += UpdateInventoryUI;
            foreach (InventoryItems item in initialItems)
            {
                if (item.IsEmpty)
                    continue;
                _inventoryData.AddItem(item.ItemSO, 1);
            }
        }
        #endregion
        #region Update Inventory
        private void UpdateInventoryUI(Dictionary<int, InventoryItems> inventoryState)
        {
            _inventoryPage.ResetAllItems();
            foreach (var item in inventoryState)
            {
                _inventoryPage.UpdateData(item.Key, item.Value.ItemSO.ItemImage,
                    item.Value.Quantity);
            }
        }
        #endregion
        #region Handle Events
        private void HandleItemActionRequest(int itemIndex)
        {
            InventoryItems inventoryItem = _inventoryData.GetItemAt(itemIndex);
            if (inventoryItem.IsEmpty)
                return;

            IItemAction itemAction = inventoryItem.ItemSO as IItemAction;
            if(itemAction != null)
            {
                itemAction.PerformAction(this.gameObject);
            }
            IDestroyableItem destroyableItem = inventoryItem.ItemSO as IDestroyableItem;
            if(destroyableItem != null)
            {
                _inventoryData.RemoveItem(itemIndex, 1);
            }
        }

        private void HandleDescriptionRequest(int itemIndex)
        {
            InventoryItems inventoryItem = _inventoryData.GetItemAt(itemIndex);
            if (inventoryItem.IsEmpty)
            {
                _inventoryPage.ResetSelection();
                return;
            }
            Item item = inventoryItem.ItemSO;
            _inventoryPage.UpdateDescription(itemIndex, item.ItemImage, item.Name, item.Description);
        }
        #endregion
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