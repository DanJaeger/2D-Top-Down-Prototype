using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    [SerializeField] GameObject ShopIntroPanel;
    [SerializeField] GameObject ShopMenuPanel;
    [SerializeField] GameObject InventoryPanel;
    private void Start()
    {
        //ShopIntroPanel.SetActive(false);
    }
    public void DisplayIntroPanel()
    {
        ShopIntroPanel.SetActive(true);
    }
    public void ChangeToInventory()
    {
        ShopMenuPanel.SetActive(false);
        InventoryPanel.SetActive(true);
    }
    public void ChangeToShop()
    {
        InventoryPanel.SetActive(false);
        ShopMenuPanel.SetActive(true);
    }
}
