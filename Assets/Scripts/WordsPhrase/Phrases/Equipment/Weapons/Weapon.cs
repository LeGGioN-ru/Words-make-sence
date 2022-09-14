using UnityEngine;

[CreateAssetMenu(fileName = "new Weapon", menuName = "Equipment/Weapon", order = 51)]
public class Weapon : Equipment
{
    [SerializeField] private float _damage;
    [SerializeField] private float _attackDelay;

    public float AttackDelay => _attackDelay;

    public virtual void Attack(Animator fighterAnimator, Fighter attacker)
    {
        attacker.EnemyFighter.TakeDamage(_damage);
        fighterAnimator.Play(FighterAnimationController.States.Attack);
    }
}
