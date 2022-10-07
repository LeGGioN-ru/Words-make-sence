using System;
using UnityEngine;

[CreateAssetMenu(fileName = "new Amulet", menuName = "Artifacts/Buff/ManaArtifact", order = 51)]
public class ManaArtifact : Artifact
{
    public override void Init(Player player)
    {
        player.IncreaseMana(Convert.ToInt32(Value));
        base.Init(player);
    }

    public override void Use()
    {
        Player.DecreaseMana(Convert.ToInt32(Value));
        base.Use();
    }
}
