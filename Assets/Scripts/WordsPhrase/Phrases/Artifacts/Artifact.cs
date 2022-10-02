using UnityEngine;
using UnityEngine.Events;

public abstract class Artifact : Phrase
{
    [SerializeField] protected float Value;

    public event UnityAction Used;

    public float CurrentValue=>Value;

    protected Player Player;

    public virtual void Init(Player player)
    {
        Player = player;
    }

    public virtual void Use()
    {
        Used?.Invoke();
    }
}
