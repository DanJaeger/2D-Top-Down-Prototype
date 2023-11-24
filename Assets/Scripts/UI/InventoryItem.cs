using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private Image _itemImage;
    [SerializeField] private TMP_Text _quantityText;

    [SerializeField] private Image _borderImage;

    public event Action<InventoryItem> OnItemClicked, OnItemDroppedOn, OnItemBeginDrag, OnItemEndDrag, OnRightMouseBtnClicked;

    private bool _isEmpty = false;

    private void Awake()
    {
        ResetData();
        Deselect();
    }
    private void ResetData()
    {
        this._itemImage.gameObject.SetActive(false);
        _isEmpty = true;
    }
    private void Deselect()
    {
        _borderImage.enabled = false;
    }
    public void SetData(Sprite sprite, int quantity)
    {
        this._itemImage.gameObject.SetActive(true);
        this._itemImage.sprite = sprite;
        this._quantityText.text = quantity + "";
        _isEmpty = false;
    }
    public void Select()
    {
        _borderImage.enabled = true;
    }
    public void OnBeginDrag()
    {
        if (_isEmpty)
            return;
        OnItemBeginDrag?.Invoke(this);
    }
    public void OnDrop()
    {
        OnItemDroppedOn?.Invoke(this);
    }
    public void OnEndDrag()
    {
        OnItemEndDrag?.Invoke(this);
    }
    public void OnPointerClick(BaseEventData data)
    {
        if (_isEmpty)
            return;

        PointerEventData pointerData = (PointerEventData)data;
        if(pointerData.button == PointerEventData.InputButton.Right)
        {
            OnRightMouseBtnClicked?.Invoke(this);
        }
        else
        {
            OnItemClicked?.Invoke(this);
        }
    }
}
