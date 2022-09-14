using UnityEngine;

[RequireComponent(typeof(Fighter))]
public class AttackState : State
{
    private float _passedAttackTime;
    private float _passedCastTime;
    private Fighter _currentFighter;

    private void OnEnable()
    {
        Animator.SetBool(FighterAnimationController.Params.IsRun, false);
        _currentFighter = GetComponent<Fighter>();
    }

    private void Update()
    {
        if (_currentFighter.CurrentWeapon != null)
            TryAttack();

        if (_currentFighter.CurrentMagic != null)
            TryCast();

        _passedCastTime += Time.deltaTime;
        _passedAttackTime += Time.deltaTime;
    }

    private void TryAttack()
    {
        if (_passedAttackTime >= _currentFighter.CurrentWeapon.AttackDelay)
        {
            _currentFighter.CurrentWeapon.Attack(Animator, _currentFighter);
            _passedAttackTime = 0;
        }
    }

    private void TryCast()
    {
        if (_passedCastTime >= _currentFighter.CurrentMagic.CastDelay)
        {
            _currentFighter.CurrentMagic.Cast(_currentFighter);
            _passedCastTime = 0;
        }
    }
}
