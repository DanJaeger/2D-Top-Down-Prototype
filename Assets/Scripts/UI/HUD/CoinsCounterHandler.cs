using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HUD
{
    public class CoinsCounterHandler : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _quantity;
        private int _currentCoins;
        public int CurrentCoins { get => _currentCoins; set => _currentCoins = value; }
        private void Awake()
        {
            _quantity = GetComponentInChildren<TextMeshProUGUI>();
        }
        void Start()
        {
            _currentCoins = 20;
            _quantity.text = "x:" + _currentCoins;
        }
        public void AddCoins(int value)
        {
            _currentCoins += value;
            _quantity.text = "x:" + _currentCoins;
        }
        public void SpendCoins(int value)
        {
            _currentCoins -= value;
            _quantity.text = "x:" + _currentCoins;
        }
    }
}