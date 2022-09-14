using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(FighterFinder))]
public class Fighter : MonoBehaviour
{
    [SerializeField] private Weapon _startWeapon;
    [SerializeField] private Armor _startArmor;
    [SerializeField] private Magic _startMagic;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _maxMana;

    public Weapon CurrentWeapon { get; protected set; }
    public Armor CurrentArmor { get; protected set; }
    public Magic CurrentMagic { get; protected set; }

    public float MaxHealth => _maxHealth;
    public float CurrentHealth => _currentHealth;
    public Fighter EnemyFighter => _enemyFighter;

    private Fighter _enemyFighter;
    private float _currentHealth;
    private float _currentMana;
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

    public void TakeDamage(float damage)
    {
        int maxPercent = 100;
        float finalDamage = damage;

        if (CurrentArmor != null)
            finalDamage = damage / maxPercent * (maxPercent - CurrentArmor.DefendPercent);

        _animator.Play(FighterAnimationController.States.TakeDamage);
        _currentHealth -= finalDamage;
    }

    public void Heal(float healPoints)
    {
        _currentHealth += healPoints;
    }

    public void SetEnemy(Fighter fighter)
    {
        if (fighter == null)
            return;

        _enemyFighter = fighter;
    }
}
