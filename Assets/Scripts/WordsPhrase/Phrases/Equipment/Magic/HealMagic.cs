using UnityEngine;

[CreateAssetMenu(fileName = "new HealMagic", menuName = "Equipment/Magic/Heal", order = 51)]
public class HealMagic : Magic
{
    [SerializeField] private float _healPercent;

    public override void Cast(Fighter caster)
    {
        float maxPercent = 100;

        float generalHeal = caster.MaxHealth / maxPercent * _healPercent;

        if (caster.CurrentHealth + generalHeal < caster.MaxHealth)
        {
            caster.Heal(generalHeal);
        }
    }
}
