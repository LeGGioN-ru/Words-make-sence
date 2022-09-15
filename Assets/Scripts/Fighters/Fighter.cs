using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(FighterFinder))]
public class Fighter : MonoBehaviour
{
    [SerializeField] private Weapon _startWeapon;
    [SerializeField] private Armor _startArmor;
    [SerializeField] private Magic _startMagic;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _maxMana;

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int, int> ManaChanged;

    public Weapon CurrentWeapon { get; protected set; }
    public Armor CurrentArmor { get; protected set; }
    public Magic CurrentMagic { get; protected set; }

    public Fighter EnemyFighter => _enemyFighter;
    public int MaxHealth => _maxHealth;
    public int CurrentHealth => _currentHealth;

    private Fighter _enemyFighter;
    private int _currentHealth;
    private int _currentMana;
    private Animator _animator;

    private void Start()
    {
        CurrentWeapon = _startWeapon;
        CurrentArmor = _startArmor;
        CurrentMagic = _startMagic;
        _currentHealth = _maxHealth;
        _currentMana = _maxMana;
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        int finalDamage = CalculateDamage(damage);

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

    private int CalculateDamage(int damage)
    {
        int maxPercent = 100;
        int finalDamage = damage;

        if (CurrentArmor != null)
            finalDamage = Convert.ToInt32(Convert.ToSingle(damage) / maxPercent * (maxPercent - CurrentArmor.DefendPercent));

        return finalDamage;
    }
}
