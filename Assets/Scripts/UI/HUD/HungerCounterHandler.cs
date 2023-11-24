using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HUD
{
    public class HungerCounterHandler : MonoBehaviour
    {
        private Slider _hungerBar;
        private float _hungerPercentage;
        private float _hungerDecayRate = 0.1f;

        private void Awake()
        {
            _hungerPercentage = 70;
            _hungerBar = GetComponentInChildren<Slider>();
        }
        private void Start()
        {
            _hungerBar.value = _hungerPercentage;
        }

        void Update()
        {
            IncreaseHunger();
        }
        void IncreaseHunger()
        {
            if (_hungerPercentage >= 0)
            {
                _hungerPercentage -= Time.deltaTime * _hungerDecayRate;
                Mathf.Clamp(_hungerPercentage, 0, 100);
                _hungerBar.value = _hungerPercentage;
            }
        }
        public void FeedCharacter(float value)
        {
            _hungerPercentage += value;
            Mathf.Clamp(_hungerPercentage, 0, 100);
        }
    }
}