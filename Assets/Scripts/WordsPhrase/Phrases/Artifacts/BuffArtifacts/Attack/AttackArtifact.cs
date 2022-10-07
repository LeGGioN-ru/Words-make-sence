using UnityEngine;

[CreateAssetMenu(fileName = "new Amulet", menuName = "Artifacts/Buff/AttackAmulet", order = 51)]
public class AttackArtifact : Artifact
{
    private WeaponHolder _weaponHolder;

    public override void Init(Player player)
    {
        _weaponHolder = player.GetComponent<WeaponHolder>();
        _weaponHolder.IncreaseAttackMultiplier(Value);
        base.Init(player);
    }

    public override void Use()
    {
        _weaponHolder.ReduceAttackMultuplier(Value);
        base.Use();
    }
}
