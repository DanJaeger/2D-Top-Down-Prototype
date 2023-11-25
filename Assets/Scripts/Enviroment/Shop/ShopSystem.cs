
using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    [SerializeField] GameObject _shopIntroPanel;
    [SerializeField] GameObject _shopMenuPanel;
    [SerializeField] GameObject _inventoryPanel;

    [SerializeField] GameObject _shopButton;
    [SerializeField] GameObject _sellButton;
    [SerializeField] GameObject _sellPriceText;

    private bool _haveIEnterBefore;
    private void Start()
    {
        _shopIntroPanel.SetActive(false);
        _shopMenuPanel.SetActive(false);
        _sellPriceText.SetActive(false);

        _haveIEnterBefore = false;
    }
    public void OpenShop()
    {
        if (!_haveIEnterBefore)
        {
            _shopIntroPanel.SetActive(true);
            _haveIEnterBefore = true;
        }
        else
        {
            if (_shopMenuPanel.activeSelf || _inventoryPanel.activeSelf)
            {
                _shopMenuPanel.SetActive(false);
                _inventoryPanel.SetActive(false);
                _shopButton.SetActive(false);
                _sellButton.SetActive(false);
                _sellPriceText.SetActive(false);
            }
            else
            {
                _shopMenuPanel.SetActive(true);
            }
        }
    }
    public void ChangeToInventory()
    {
        _shopMenuPanel.SetActive(false);
        _inventoryPanel.SetActive(true);
        _shopButton.SetActive(true);
        _sellButton.SetActive(true);
        _sellPriceText.SetActive(true);
    }
    public void ChangeToShop()
    {
        _inventoryPanel.SetActive(false);
        _shopButton.SetActive(false);
        _sellButton.SetActive(false);
        _sellPriceText.SetActive(false);
        _shopMenuPanel.SetActive(true);
    }
}
