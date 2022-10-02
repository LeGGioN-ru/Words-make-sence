using UnityEngine;

[CreateAssetMenu(fileName = "new DamageMagic", menuName = "Equipment/Magic/Damage", order = 51)]
public class DamageMagic : Magic
{
    public override void TryCast(Fighter caster, Animator animator)
    {
        caster.Enemy.TakeDamage(Value);
        animator.Play(FighterAnimationController.States.Magic);
    }
}
