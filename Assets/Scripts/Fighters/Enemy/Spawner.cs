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
    public event UnityAction EnemiesEnded;

    private int _evilLevel;
    private Enemy _currentEnemy;

    private void Start()
    {
        EvilIncreased?.Invoke(_evilLevel);
        StartCoroutine(EvilIncreasing());
        StartCoroutine(Spawning());
    }

    private IEnumerator EvilIncreasing()
    {
        WaitForSeconds delay = new WaitForSeconds(_evilIncreaseDelay);

        while (true)
        {
            yield return delay;
            IncreaseEvil();
        }
    }

    private IEnumerator Spawning()
    {
        WaitForSeconds delay = new WaitForSeconds(_spawnDelay);

        do
        {
            Execute();
            yield return delay;
        } 
        while (TryEndGame() == false);
    }

    private void IncreaseEvil()
    {
        _evilLevel++;
        EvilIncreased?.Invoke(_evilLevel);
    }

    private void Execute()
    {
        if (_currentEnemy != null)
            return;

        if (_enemyPacks[_evilLevel].TryGetRandomEnemy(out Enemy enemy))
        {
            _currentEnemy = Instantiate(enemy, _spawnPoint);

            if (_currentEnemy is Boss)
                IncreaseEvil();

            EnemySpawned?.Invoke(_currentEnemy);
        }
    }

    private bool TryEndGame()
    {
        if (_currentEnemy != null || _enemyPacks.Count > _evilLevel)
            return false;

        StopCoroutine(EvilIncreasing());
        StopCoroutine(Spawning());
        EnemiesEnded?.Invoke();
        enabled = false;

        return true;
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
