using UnityEngine;

[RequireComponent(typeof(Fighter))]
public class HealthEndTransition : Transition
{
    private Fighter _fighter;

    private void Start()
    {
        _fighter = GetComponent<Fighter>();
    }

    private void Update()
    {
        if (_fighter.CurrentHealth <= 0)
        {
            NeedTransit = true;
        }
    }
}
