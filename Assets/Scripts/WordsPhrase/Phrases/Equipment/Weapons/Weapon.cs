using UnityEngine;

[CreateAssetMenu(fileName = "new Weapon", menuName = "Equipment/Weapon", order = 51)]
public class Weapon : Equipment
{
    [SerializeField] private int _damage;
    [SerializeField] private float _attackDelay;

    public float AttackDelay => _attackDelay;
    public int Damage => _damage;

    public virtual void Attack(Fighter attacker, int finalDamage)
    {
        var enemyArmor = attacker.Enemy.GetComponent<ArmorHolder>();

        enemyArmor.CalculateDamage(finalDamage);
    }
}
