using UnityEngine;

public class FighterFindTransition : Transition
{
    [SerializeField] private FighterFinder _fighterFinder;

    private Fighter _fighter;

    private void Update()
    {
        _fighter = _fighterFinder.Execute();

        if (_fighter != null)
        {
            CurrentFighter.SetEnemy(_fighter);
            NeedTransit = true;
        }
    }
}
