using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    private float _passedAttackTime;

    private void TryAttack()
    {
        if (_passedAttackTime >= _weapon.AttackDelay)
        {
            _weapon.Attack(Animator, _currentFighter);
            _passedAttackTime = 0;
        }
    }

    private float CalculateFinalDamage()
    {

    }
}
