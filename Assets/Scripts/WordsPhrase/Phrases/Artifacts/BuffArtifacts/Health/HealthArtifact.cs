using System;
using UnityEngine;

[CreateAssetMenu(fileName = "new Amulet", menuName = "Artifacts/Buff/HealAmulet", order = 51)]
public class HealthArtifact : Artifact
{
    public override void Init(Player player)
    {
        player.IncreaseHealth(Convert.ToInt32(Value));
        base.Init(player);
    }

    public override void Use()
    {
        Player.DecreaseHealth(Convert.ToInt32(Value));
        base.Use();
    }
}
