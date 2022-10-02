using System;
using UnityEngine;

public class WeaponHolder : EquipmentHolder
{
    [SerializeField] private AttackState _attackState;
    [SerializeField] private Weapon _weapon;

    private float _attackMultiplier = 1;

    protected override void Start()
    {
        OnChanged(_weapon);
    }

    protected override void OnEnable()
    {
        _attackState.AttackStarted += OnAttackStarted;
        base.OnEnable();
    }

    protected override void OnDisable()
    {
        _attackState.AttackStarted -= OnAttackStarted;
        base.OnDisable();
    }

    public void IncreaseAttackMultiplier(float buff)
    {
        _attackMultiplier += buff;
    }

    public void ReduceAttackMultuplier(float buff)
    {
        _attackMultiplier -= buff;
    }

    protected override void OnChanged(Equipment equipment)
    {
        if (equipment is Weapon weapon)
        {
            _weapon = weapon;
            base.OnChanged(equipment);
        }
    }

    protected void OnAttackStarted()
    {
        if (_weapon == null)
            return;

        if (PassedTime >= _weapon.AttackDelay)
        {
            Animator.Play(FighterAnimationController.States.Attack);
            _weapon.Attack(Fighter, CalculateFinalDamage());
            PassedTime = 0;
        }

        PassedTime += Time.deltaTime;
    }

    private int CalculateFinalDamage()
    {
        return Convert.ToInt32(_weapon.Damage * _attackMultiplier);
    }
}
