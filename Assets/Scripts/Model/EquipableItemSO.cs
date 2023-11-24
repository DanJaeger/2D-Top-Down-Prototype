using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Model
{
    [CreateAssetMenu]
    public class EquipableItemSO : Item, IDestroyableItem, IItemAction
    {
        [SerializeField] private List<ModifierData> modifiersData = new List<ModifierData>();
        public string ActionName => "Equip";

        [field: SerializeField]
        public AudioClip actionSFX { get; private set; }

        public bool PerformAction(GameObject character/*, List<ItemParameter> itemState = null*/)
        {
            foreach (ModifierData data in modifiersData)
            {
                data.statModifier.AffectCharacter(character, data.value);
            }
            return true;
        }
    }
}