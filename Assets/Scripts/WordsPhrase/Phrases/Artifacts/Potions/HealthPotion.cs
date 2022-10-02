using System;
using UnityEngine;

[CreateAssetMenu(fileName = "new Artifact", menuName = "Artifacts/HealthPotion", order = 51)]
public class HealthPotion : Artifact
{
    public override void Init(Player player)
    {
        base.Init(player);
        Player.HealthChanged += OnHealthChanged;
    }

    private void OnHealthChanged(int currentHealth, int maxHealth)
    {
        if (maxHealth - currentHealth >= Value)
        {
            Player.Heal(Convert.ToInt32(Value));
            Use();
        }
    }

    public override void Use()
    {
        Player.HealthChanged -= OnHealthChanged;
        base.Use();
    }
}
