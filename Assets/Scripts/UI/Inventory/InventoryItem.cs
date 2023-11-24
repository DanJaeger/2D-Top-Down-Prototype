using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Inventory.UI
{
    public class InventoryItem : MonoBehaviour
    {
        [SerializeField] private Image _itemImage;
        [SerializeField] private TMP_Text _quantityText;

        [SerializeField] private Image _borderImage;

        public event Action<InventoryItem> OnItemClicked, OnRightMouseBtnClicked;

        private bool _isEmpty = false;

        private void Awake()
        {
            ResetData();
            Deselect();
        }
        private void ResetData()
        {
            _itemImage.gameObject.SetActive(false);
            _isEmpty = true;
        }
        public void Deselect()
        {
            _borderImage.enabled = false;
        }
        public void SetData(Sprite sprite, int quantity)
        {
            _itemImage.gameObject.SetActive(true);
            _itemImage.sprite = sprite;
            _quantityText.text = quantity + "";
            _isEmpty = false;
        }
        public void Select()
        {
            _borderImage.enabled = true;
        }
        public void OnPointerClick(BaseEventData data)
        {
            PointerEventData pointerData = (PointerEventData)data;
            if (pointerData.button == PointerEventData.InputButton.Right)
            {
                OnRightMouseBtnClicked?.Invoke(this);
            }
            else
            {
                OnItemClicked?.Invoke(this);
            }
        }
    }
}