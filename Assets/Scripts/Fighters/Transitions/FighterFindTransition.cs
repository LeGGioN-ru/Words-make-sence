using UnityEngine;

public class FighterFindTransition : Transition
{
    [SerializeField] private FighterFinder _fighterFinder;

    private Fighter _enemyFighter;

    private void Update()
    {
        _enemyFighter = _fighterFinder.Execute();

        if (_enemyFighter != null)
        {
            CurrentFighter.SetEnemy(_enemyFighter);
            NeedTransit = true;
        }
    }
}
