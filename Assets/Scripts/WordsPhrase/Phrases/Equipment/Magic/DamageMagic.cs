using UnityEngine;

[CreateAssetMenu(fileName = "new DamageMagic", menuName = "Equipment/Magic/Damage", order = 51)]
public class DamageMagic : Magic
{
    [SerializeField] private float _damage;

    public override void Cast(Fighter caster)
    {
        caster.EnemyFighter.TakeDamage(_damage);
    }
}
