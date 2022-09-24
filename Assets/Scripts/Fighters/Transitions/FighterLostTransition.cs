using UnityEngine;

public class FighterLostTransition : Transition
{
    [SerializeField] private FighterFinder _fighterFinder;

    private void Update()
    {
        if (CurrentFighter.Enemy == null)
        {
            NeedTransit = true;
        }
    }
}
