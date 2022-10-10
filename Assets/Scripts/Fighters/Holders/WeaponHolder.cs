using System;
using UnityEngine;

public class WeaponHolder : EquipmentHolder
{
    [SerializeField] private AttackState _attackState;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private AudioSource _attackSound;

    private float _attackMultiplier = 1;

    protected override void Start()
    {
        OnActivated(_weapon);
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

    protected void OnAttackStarted()
    {
        if (_weapon == null)
            return;

        if (PassedTime >= _weapon.AttackDelay)
        {
            Attack();
            PassedTime = 0;
        }

        PassedTime += Time.deltaTime;
    }

    private int CalculateFinalDamage()
    {
        return Convert.ToInt32(_weapon.Damage * _attackMultiplier);
    }

    protected override void OnActivated(Phrase phrase)
    {
        if (phrase is Weapon weapon)
        {
            _weapon = weapon;
            _attackSound.clip = _weapon.SoundSettings.Sound;
            Change(weapon);
        }
    }

    private void Attack()
    {
        Animator.Play(FighterAnimationController.States.Attack);
        _weapon.SoundSettings.TryPlaySound(_attackSound);
        _weapon.Attack(Fighter, CalculateFinalDamage());
    }
}
