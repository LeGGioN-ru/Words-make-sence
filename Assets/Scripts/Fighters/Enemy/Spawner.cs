using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<EnemyPack> _enemyPacks;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private int _evilIncreaseDelay;
    [SerializeField] private float _spawnDelay;

    public event UnityAction<int> EvilIncreased;
    public event UnityAction<Enemy> EnemySpawned;

    private int _evilLevel;
    private float _passedTime;
    private Enemy _currentEnemy;

    private void Start()
    {
        EvilIncreased?.Invoke(_evilLevel);
        StartCoroutine(EvilIncrease());
    }

    private void Update()
    {
        if (_currentEnemy == null)
            _passedTime += Time.deltaTime;

        if (_passedTime >= _spawnDelay)
        {
            _currentEnemy = Instantiate(_enemyPacks[_evilLevel].GetRandomEnemy(), _spawnPoint);


            EnemySpawned?.Invoke(_currentEnemy);
            _passedTime = 0;
        }
    }

    private IEnumerator EvilIncrease()
    {
        while (_evilLevel < _enemyPacks.Count - 1)
        {
            yield return new WaitForSeconds(_evilIncreaseDelay);
            _evilLevel++;
            EvilIncreased?.Invoke(_evilLevel);
        }
    }
}

[Serializable]
public class EnemyPack
{
    [SerializeField] private List<Enemy> _enemies;

    public Enemy GetRandomEnemy()
    {
        return _enemies[UnityEngine.Random.Range(0, _enemies.Count)];
    }
}
