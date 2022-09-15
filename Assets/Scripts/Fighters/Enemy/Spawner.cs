using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<EnemyPack> _enemyPacks;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private int _evilIncreaseDelay;
    [SerializeField] private float _spawnDelay;

    private int _evilLevel;
    private float _passedTime;
    private Enemy _currentEnemy;

    private void Start()
    {
        StartCoroutine(EvilIncrease());
    }

    private void Update()
    {
        if (_currentEnemy == null)
            _passedTime += Time.deltaTime;

        if (_passedTime >= _spawnDelay)
        {
            _currentEnemy = Instantiate(_enemyPacks[_evilLevel].GetRandomEnemy(), _spawnPoint);
            _passedTime = 0;
        }
    }

    private IEnumerator EvilIncrease()
    {
        while (_evilLevel < _enemyPacks.Count)
        {
            yield return new WaitForSeconds(_evilIncreaseDelay);
            _evilLevel++;
        }
    }
}

[Serializable]
public class EnemyPack
{
    [SerializeField] private List<Enemy> _enemies;

    public Enemy GetRandomEnemy()
    {
        return _enemies[UnityEngine.Random.Range(0, _enemies.Count - 1)];
    }
}
