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
    [SerializeField] private float _regenerationDelay = 5;

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int, int> ManaChanged;
    public event UnityAction Died;

    public int MaxHealth => _maxHealth;
    public int CurrentHealth => _currentHealth;
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
        _currentHealth += healPoints;
        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }

    public void SetEnemy(Fighter fighter)
    {
        if (fighter == null)
            return;

        _enemy = fighter;
    }
}
