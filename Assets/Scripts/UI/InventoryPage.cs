using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPage : MonoBehaviour
{
    [SerializeField] private InventoryItem _itemPrefab;
    [SerializeField] private InventoryDescription _itemDescription;
    [SerializeField] private RectTransform _contentPanel;

    List<InventoryItem> _listOfItems = new List<InventoryItem>();

    [SerializeField] Sprite _testImage;
    [SerializeField] int _testQuantity;
    [SerializeField] string _testTitle, _testDescription;

    private void Awake()
    {
        Hide();
        _itemDescription.ResetDescription();
    }

    public void InitializeInventoryUI(int inventorySize)
    {
        for(int i = 0; i < inventorySize; i++)
        {
            InventoryItem uiItem = Instantiate(_itemPrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(_contentPanel);
            _listOfItems.Add(uiItem);

            uiItem.OnItemClicked += HandleItemSelection;
            uiItem.OnItemBeginDrag += HandleBeginDrag;
            uiItem.OnItemDroppedOn += HandleItemSwap;
            uiItem.OnItemEndDrag += HandleEndDrag;
            uiItem.OnRightMouseBtnClicked += HandleShowItemActions;
        }
    }

    private void HandleShowItemActions(InventoryItem item)
    {
        
    }

    private void HandleEndDrag(InventoryItem item)
    {
        
    }

    private void HandleItemSwap(InventoryItem item)
    {
        
    }

    private void HandleBeginDrag(InventoryItem item)
    {
        
    }

    private void HandleItemSelection(InventoryItem item)
    {
        _itemDescription.SetDescription(_testImage, _testTitle, _testDescription);
        _listOfItems[0].Select();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        _itemDescription.ResetDescription();

        _listOfItems[0].SetData(_testImage, _testQuantity);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
