using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<EnemyPack> _enemyPacks;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private int _evilIncreaseDelay;

    public event UnityAction<int> EvilIncreased;
    public event UnityAction<Enemy> EnemySpawned;

    private int _evilLevel;
    private float _passedTime;
    private Enemy _currentEnemy;

    private void Start()
    {
        EvilIncreased?.Invoke(_evilLevel);
        StartCoroutine(EvilIncreasing());
    }

    private void Update()
    {
        if (_currentEnemy == null)
            _passedTime += Time.deltaTime;

        if (_passedTime >= _spawnDelay)
        {
            Execute();
            _passedTime = 0;
        }
    }

    private IEnumerator EvilIncreasing()
    {
        while (_evilLevel < _enemyPacks.Count - 1)
        {
            yield return new WaitForSeconds(_evilIncreaseDelay);
            IncreaseEvil();
        }
    }

    private void IncreaseEvil()
    {
        _evilLevel++;
        EvilIncreased?.Invoke(_evilLevel);
    }

    private void Execute()
    {
        if (_enemyPacks[_evilLevel].TryGetRandomEnemy(out Enemy enemy))
        {
            _currentEnemy = Instantiate(enemy, _spawnPoint);

            if (_currentEnemy is Boss)
                IncreaseEvil();

            EnemySpawned?.Invoke(_currentEnemy);
        }
    }
}

[Serializable]
public class EnemyPack
{
    [SerializeField] private List<Enemy> _enemies;

    public bool TryGetRandomEnemy(out Enemy enemy)
    {
        enemy = null;

        if (_enemies.Count > 0)
            enemy = _enemies[UnityEngine.Random.Range(0, _enemies.Count)];

        if (enemy == null)
            return false;

        return true;
    }
}
