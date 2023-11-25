using Inventory.Model;
using Inventory.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

namespace Shop.UI
{
    public class UIShopPage : MonoBehaviour
    {
        [SerializeField] private InventoryDescription _itemDescription;
        [SerializeField] private RectTransform _contentPanel;

        [SerializeField] List<UIInventoryShop> _listOfItems = new List<UIInventoryShop>();

        public event Action<int> OnDescriptionRequested;
        private void Awake()
        {
            _itemDescription.ResetDescription();
        }
        public void InitializeShopInventoryUI()
        {
            foreach (UIInventoryShop item in _listOfItems)
            {
                item.OnItemClicked += HandleItemSelection;
            }
        }
        internal void UpdateDescription(int itemIndex, Sprite itemImage, string name, string description)
        {
            _itemDescription.SetDescription(itemImage, name, description);
            DeselectAllItems();
            _listOfItems[itemIndex].Select();
        }
        public void UpdateData(int itemIndex, Sprite itemImage, int itemQuantity)
        {
            if (_listOfItems.Count > itemIndex)
            {
                _listOfItems[itemIndex].SetData(itemImage, itemQuantity);
            }
        }
        private void HandleItemSelection(UIInventoryShop item)
        {
            int index = _listOfItems.IndexOf(item);
            if (index == -1)
                return;
            OnDescriptionRequested?.Invoke(index);
        }
        public void ResetSelection()
        {
            _itemDescription.ResetDescription();
            DeselectAllItems();
        }
        private void DeselectAllItems()
        {
            foreach (UIInventoryShop item in _listOfItems)
            {
                item.Deselect();
            }
        }
        internal void ResetAllItems()
        {
            foreach (var item in _listOfItems)
            {
                item.Deselect();
            }
        }
    }
}