using UnityEngine;

[CreateAssetMenu(fileName = "new Weapon", menuName = "Equipment/Weapons/PercentDamageWeapon", order = 51)]
public class PercentDamageWeapon : Weapon
{
    [SerializeField] private int _percentDamage;

    public override void Attack(Fighter attacker, int finalDamage)
    {
        base.Attack(attacker, finalDamage);

        int additionalDamage = attacker.Enemy.MaxHealth / 100 * _percentDamage;

        attacker.Enemy.TakeDamage(additionalDamage);
    }
}
