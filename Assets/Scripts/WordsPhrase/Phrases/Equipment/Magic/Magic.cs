using UnityEngine;

public abstract class Magic : Equipment
{
    [SerializeField] private int _manaCost;
    [SerializeField] private float _castDelay;
    [SerializeField] protected int Value;

    public float CastDelay => _castDelay;
    public int ManaCost => _manaCost;
    public int CurrentValue => Value;

    public abstract void TryCast(Fighter caster, Animator animator);
}
