using UnityEngine;

public class PlayerManaBar : Bar
{
    [SerializeField] protected Player Player;

    protected override void OnEnable()
    {
        Player.ManaChanged += OnChange;
    }

    protected override void OnDisable()
    {
        Player.ManaChanged -= OnChange;
    }
}
