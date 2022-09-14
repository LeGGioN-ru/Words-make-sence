using UnityEngine;

public abstract class Magic : Equipment
{
    [SerializeField] private float _manaCost;
    [SerializeField] private float _castDelay;

    public float CastDelay => _castDelay;

    public abstract void Cast(Fighter caster);
}
