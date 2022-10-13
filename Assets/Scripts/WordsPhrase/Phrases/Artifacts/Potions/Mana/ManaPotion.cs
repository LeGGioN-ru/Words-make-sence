using System;
using UnityEngine;

[CreateAssetMenu(fileName = "new Artifact", menuName = "Artifacts/Potion/ManaPotion", order = 51)]
public class ManaPotion : Potion
{
    public override void Init(Player player)
    {
        base.Init(player);
        Player.ManaChanged += TryRecoverMana;
    }

    private void TryRecoverMana(int currentMana, int maxMana)
    {
        MissingValue = maxMana - currentMana;

        if (MissingValue >= Value)
        {
            Use();
        }
    }

    public override void Use()
    {
        Player.RecoverMana(Convert.ToInt32(Value));
        Player.ManaChanged -= TryRecoverMana;
        base.Use();
    }
}
