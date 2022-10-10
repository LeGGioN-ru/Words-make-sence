using UnityEngine;

public abstract class Magic : Equipment
{
    [SerializeField] private int _manaCost;
    [SerializeField] private float _castDelay;
    [SerializeField] protected int Value;
    [SerializeField] private SoundSettings _soundSettings;

    public SoundSettings SoundSettings => _soundSettings;
    public float CastDelay => _castDelay;
    public int ManaCost => _manaCost;
    public int CurrentValue => Value;

    public abstract void Cast(Fighter caster, Animator animator);

    public virtual bool CheckAvalible(float passedTime, Fighter fighter)
    {
        if (passedTime < CastDelay || ManaCost > fighter.CurrentMana)
            return false;

        return true;
    }
}
