using System;
using UnityEngine;

[CreateAssetMenu(fileName = "new Artifact", menuName = "Artifacts/Potion/HealthPotion", order = 51)]
public class HealthPotion : Potion
{
    public override void Init(Player player)
    {
        base.Init(player);
        Player.HealthChanged += OnHealthChanged;
    }

    private void OnHealthChanged(int currentHealth, int maxHealth)
    {
        MissingValue = maxHealth - currentHealth;

        if (MissingValue >= Value || currentHealth <= Threshold)
        {
            Use();
        }
    }

    public override void Use()
    {
        Player.HealthChanged -= OnHealthChanged;
        Player.Heal(Convert.ToInt32(Value));
        base.Use();
    }
}
