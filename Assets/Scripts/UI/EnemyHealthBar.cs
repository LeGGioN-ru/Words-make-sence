using TMPro;
using UnityEngine;

public class EnemyHealthBar : Bar
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private TMP_Text _text;

    private Enemy _enemy;

    protected override void OnEnable()
    {
        _spawner.EnemySpawned += OnEnemySpawned;
    }

    protected override void OnDisable()
    {
        _spawner.EnemySpawned -= OnEnemySpawned;
    }

    private void OnEnemySpawned(Enemy enemy)
    {
        _enemy = enemy;
        _text.text = enemy.Name;
        OnChange(enemy.MaxHealth, enemy.CurrentHealth);
        _enemy.Died += OnDied;
        _enemy.HealthChanged += OnChange;
    }

    private void OnDied()
    {
        _enemy.Died -= OnDied;
        _enemy.HealthChanged -= OnChange;
    }
}
