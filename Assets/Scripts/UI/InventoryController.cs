using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private InventoryPage _inventoryPage;
    
    public int InventoryPageSize = 10;

    private void Start()
    {
        _inventoryPage.InitializeInventoryUI(InventoryPageSize);        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if(_inventoryPage.isActiveAndEnabled == false)
            {
                _inventoryPage.Show();
            }
            else
            {
                _inventoryPage.Hide();
            }
        }
    }
}
