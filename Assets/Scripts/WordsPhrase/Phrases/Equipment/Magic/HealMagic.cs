using System;
using UnityEngine;

[CreateAssetMenu(fileName = "new HealMagic", menuName = "Equipment/Magic/Heal", order = 51)]
public class HealMagic : Magic
{
    public override void TryCast(Fighter caster, Animator animator)
    {
        int maxPercent = 100;

        int generalHeal = Convert.ToInt32(Convert.ToSingle(caster.MaximumHealth) / maxPercent * Value);

        if (caster.CurrentHealth + generalHeal < caster.MaximumHealth)
        {
            caster.ReduceMana(ManaCost);
            caster.Heal(generalHeal);
            animator.Play(FighterAnimationController.States.Heal);
        }
    }
}
