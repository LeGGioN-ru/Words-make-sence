using UnityEngine;

public class PlayerHealthBar : Bar
{
    [SerializeField] protected Player Player;

    protected override void OnEnable()
    {
        Player.HealthChanged += OnChange;
    }

    protected override void OnDisable()
    {
        Player.HealthChanged -= OnChange;
    }
}
