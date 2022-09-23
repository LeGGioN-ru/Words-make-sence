using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Fighter : MonoBehaviour
{
    [SerializeField] private ArmorHolder _armorHolder;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _maxMana;

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int, int> ManaChanged;

    public Fighter EnemyFighter => _enemyFighter;
    public int MaxHealth => _maxHealth;
    public int CurrentHealth => _currentHealth;

    private Fighter _enemyFighter;
    private int _currentHealth;
    private int _currentMana;
    private Animator _animator;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _currentMana = _maxMana;
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {

        int finalDamage = damage;

        if (_armorHolder.Armor != null)
            finalDamage = _armorHolder.CalculateDamage(finalDamage);

        _animator.Play(FighterAnimationController.States.TakeDamage);
        _currentHealth -= finalDamage;

        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }

    public void Heal(int healPoints)
    {
        _currentHealth += healPoints;
        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }

    public void SetEnemy(Fighter fighter)
    {
        if (fighter == null)
            return;

        _enemyFighter = fighter;
    }
}
