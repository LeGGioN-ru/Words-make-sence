using UnityEngine;

public class MagicHolder : EquipmentHolder
{
    [SerializeField] private Magic _magic;
    [SerializeField] private AttackState _attackState;

    protected override void Start()
    {
        OnChanged(_magic);
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

    protected override void OnChanged(Equipment equipment)
    {
        if (equipment is Magic magic)
        {
            _magic = magic;
            base.OnChanged(equipment);
        }
    }

    protected void OnAttackStarted()
    {
        if (_magic == null)
            return;

        if (PassedTime >= _magic.CastDelay && _magic.ManaCost <= Fighter.CurrentMana)
        {
            _magic.TryCast(Fighter, Animator);
            PassedTime = 0;
        }

        PassedTime += Time.deltaTime;
    }
}
