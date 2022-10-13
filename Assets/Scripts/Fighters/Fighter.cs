using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(ArmorHolder))]
[RequireComponent(typeof(WeaponHolder))]
[RequireComponent(typeof(MagicHolder))]
public class Fighter : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _maxMana;

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int, int> ManaChanged;
    public event UnityAction Died;

    public int MaxMana
    {
        get
        {
            return _maxMana;
        }
        protected set
        {
            _maxMana = value;
            ManaChanged?.Invoke(_currentMana, _maxMana);
        }
    }

    public int MaxHealth
    {
        get
        {
            return _maxHealth;
        }
        protected set
        {
            _maxHealth = value;
            HealthChanged?.Invoke(_currentHealth, _maxHealth);
        }
    }

    public int CurrentHealth => _currentHealth;
    public int CurrentMana => _currentMana;
    public Fighter Enemy => _enemy;

    private Fighter _enemy;
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
        _currentHealth -= damage;
        _animator.Play(FighterAnimationController.States.TakeDamage);

        HealthChanged?.Invoke(_currentHealth, _maxHealth);

        if (_currentHealth <= 0)
            Died?.Invoke();
    }

    public void Heal(int healPoints)
    {
        if (healPoints < 0)
            return;

        _currentHealth += healPoints;
        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }

    public void RecoverMana(int mana)
    {
        if (mana < 0)
            return;

        _currentMana += mana;
        ManaChanged?.Invoke(_currentMana, _maxMana);
    }

    public void ReduceMana(int mana)
    {
        _currentMana -= mana;
        ManaChanged?.Invoke(_currentMana, _maxMana);
    }

    public void SetEnemy(Fighter fighter)
    {
        if (fighter == null)
            return;

        _enemy = fighter;
    }
}
