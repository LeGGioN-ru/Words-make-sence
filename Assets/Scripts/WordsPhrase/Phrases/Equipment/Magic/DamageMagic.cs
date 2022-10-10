using UnityEngine;

[CreateAssetMenu(fileName = "new DamageMagic", menuName = "Equipment/Magic/Damage", order = 51)]
public class DamageMagic : Magic
{
    public override void Cast(Fighter caster, Animator animator)
    {
        caster.ReduceMana(ManaCost);
        var enemyArmor = caster.Enemy.GetComponent<ArmorHolder>();
        enemyArmor.CalculateDamage(Value);

        animator.Play(FighterAnimationController.States.Magic);
    }
}
