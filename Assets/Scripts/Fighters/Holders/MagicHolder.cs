using UnityEngine;

public class MagicHolder : EquipmentHolder
{
    [SerializeField] private Magic _magic;
    [SerializeField] private AttackState _attackState;
    [SerializeField] private AudioSource _castSound;

    protected override void Start()
    {
        OnActivated(_magic);
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

    protected void OnAttackStarted()
    {
        if (_magic == null)
            return;

        if (_magic.CheckAvalible(PassedTime, Fighter))
        {
            Cast();
            PassedTime = 0;
        }

        PassedTime += Time.deltaTime;
    }

    protected override void OnActivated(Phrase phrase)
    {
        if (phrase is Magic magic)
        {
            _magic = magic;
            _castSound.clip = _magic.SoundSettings.Sound;
            Change(magic);
        }
    }

    private void Cast()
    {
        _magic.Cast(Fighter, Animator);
        _magic.SoundSettings.Play(_castSound);
    }
}
