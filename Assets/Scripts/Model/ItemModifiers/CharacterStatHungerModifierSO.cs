using HUD;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterStatHungerModifierSO : CharacterStatModifierSO
{
    public override void AffectCharacter(GameObject character, float val)
    {
        PlayerController player = character.GetComponent<PlayerController>();
        HungerCounterHandler hunger = player.Hunger;
        if(hunger != null)
        {
            hunger.FeedCharacter(val);
        }
    }
}
