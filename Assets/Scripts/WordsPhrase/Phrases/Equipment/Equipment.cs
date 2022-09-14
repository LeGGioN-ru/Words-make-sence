using UnityEngine;

public abstract class Equipment : Phrase
{
    [SerializeField] private Sprite _icon;

    public Sprite Icon => _icon;
}
