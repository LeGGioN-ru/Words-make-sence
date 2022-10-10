using System;
using UnityEngine;

[CreateAssetMenu(fileName = "new HealMagic", menuName = "Equipment/Magic/Heal", order = 51)]
public class HealMagic : Magic
{
    [SerializeField] private ParticleSystem _particles;

    private int _generalHeal;

    public override void Cast(Fighter caster, Animator animator)
    {
        caster.ReduceMana(ManaCost);
        caster.Heal(_generalHeal);
        Instantiate(_particles, caster.transform);
    }

    public override bool CheckAvalible(float passedTime, Fighter caster)
    {
        int maxPercent = 100;

        _generalHeal = Convert.ToInt32(Convert.ToSingle(caster.MaxHealth) / maxPercent * Value);

        if (caster.CurrentHealth + _generalHeal >= caster.MaxHealth)
            return false;

        return base.CheckAvalible(passedTime, caster);
    }
}
