using System;
using UnityEngine;

[CreateAssetMenu(fileName = "new Weapon", menuName = "Equipment/Weapons/DefaultWeapon", order = 51)]
public class Weapon : Equipment
{
    [SerializeField] private int _damage;
    [SerializeField] private float _attackDelay;
    [SerializeField] private SoundSettings _soundSettings;

    public SoundSettings SoundSettings => _soundSettings;
    public float AttackDelay => _attackDelay;
    public int Damage => _damage;

    public virtual void Attack(Fighter attacker, int finalDamage)
    {
        if (attacker.Enemy == null)
            return;

        var enemyArmor = attacker.Enemy.GetComponent<ArmorHolder>();

        enemyArmor.CalculateDamage(finalDamage);
    }
}