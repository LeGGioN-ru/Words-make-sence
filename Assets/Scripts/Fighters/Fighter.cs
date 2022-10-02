using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(ArmorHolder))]
[RequireComponent(typeof(WeaponHolder))]
[RequireComponent(typeof(MagicHolder))]
public class Fighter : MonoBehaviour
{
    [SerializeField] protected int MaxHealth;
    [SerializeField] protected int MaxMana;

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int, int> ManaChanged;
    public event UnityAction Died;

    public int MaximumMana => MaxMana;
    public int MaximumHealth => MaxHealth;
    public int CurrentHealth => _currentHealth;
    public int CurrentMana => _currentMana;
    public Fighter Enemy => _enemy;

    private Fighter _enemy;
    private int _currentHealth;
    private int _currentMana;
    private Animator _animator;

    private void Start()
    {
        _currentHealth = MaxHealth;
        _currentMana = MaxMana;
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _animator.Play(FighterAnimationController.States.TakeDamage);

        HealthChanged?.Invoke(_currentHealth, MaxHealth);

        if (_currentHealth <= 0)
            Died?.Invoke();
    }

    public void Heal(int healPoints)
    {
        _currentHealth += healPoints;
        HealthChanged?.Invoke(_currentHealth, MaxHealth);
    }

    public void HealMana(int mana)
    {
        _currentMana += mana;
        ManaChanged?.Invoke(_currentMana, MaxMana);
    }

    public void ReduceMana(int mana)
    {
        _currentMana -= mana;
        ManaChanged?.Invoke(_currentMana, MaxMana);
    }

    public void SetEnemy(Fighter fighter)
    {
        if (fighter == null)
            return;

        _enemy = fighter;
    }

    public void SetStats(Armor armor)
    {
        MaxHealth = armor.Health;
        MaxMana = armor.Mana;
    }
}
