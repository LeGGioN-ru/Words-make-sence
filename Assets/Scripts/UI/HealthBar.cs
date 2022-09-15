using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : Bar
{
    protected override void OnEnable()
    {
        Player.HealthChanged += OnChange;
    }

    protected override void OnDisable()
    {
        Player.HealthChanged -= OnChange;
    }
}
