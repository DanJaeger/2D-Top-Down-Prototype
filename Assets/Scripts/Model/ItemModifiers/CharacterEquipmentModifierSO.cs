using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterEquipmentModifierSO : CharacterStatModifierSO
{
    public override void AffectCharacter(GameObject character, float val)
    {
        PlayerController player = character.GetComponent<PlayerController>();
        if (val == 0)
        {
            player.ChangeClothes(IClothing.Detective);
        }else if(val == 1)
        {
            player.ChangeClothes(IClothing.Astronaut);
        }
    }
}
