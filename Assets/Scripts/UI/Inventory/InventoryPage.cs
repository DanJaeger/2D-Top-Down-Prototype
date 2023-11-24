using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Inventory.UI
{
    public class InventoryPage : MonoBehaviour
    {
        [SerializeField] private InventoryItem _itemPrefab;
        [SerializeField] private InventoryDescription _itemDescription;
        [SerializeField] private RectTransform _contentPanel;

        List<InventoryItem> _listOfItems = new List<InventoryItem>();

        public event Action<int> OnDescriptionRequested, OnItemActionRequested;

        //[SerializeField] private ItemActionPanel actionPanel;

        private void Awake()
        {
            Hide();
            _itemDescription.ResetDescription();
        }

        public void InitializeInventoryUI(int inventorySize)
        {
            for (int i = 0; i < inventorySize; i++)
            {
                InventoryItem uiItem = Instantiate(_itemPrefab, Vector3.zero, Quaternion.identity);
                uiItem.transform.SetParent(_contentPanel);
                _listOfItems.Add(uiItem);

                uiItem.OnItemClicked += HandleItemSelection;
                uiItem.OnRightMouseBtnClicked += HandleShowItemActions;
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

        private void HandleShowItemActions(InventoryItem item)
        {

        }

        private void HandleItemSelection(InventoryItem item)
        {
            int index = _listOfItems.IndexOf(item);
            if (index == -1)
                return;
            OnDescriptionRequested?.Invoke(index);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            ResetSelection();
        }

        public void ResetSelection()
        {
            _itemDescription.ResetDescription();
            DeselectAllItems();
        }
        private void DeselectAllItems()
        {
            foreach (InventoryItem item in _listOfItems)
            {
                item.Deselect();
            }
            //actionPanel.Toggle(false);
        }
        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}