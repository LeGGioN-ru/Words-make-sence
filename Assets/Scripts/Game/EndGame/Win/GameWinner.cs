using UnityEngine;

[RequireComponent(typeof(Spawner))]
public class GameWinner : GameEnder
{
    private Spawner _spawner;

    private void Awake()
    {
        _spawner = GetComponent<Spawner>();
    }

    private void OnEnable()
    {
        _spawner.EnemiesEnded += EndGame;
    }

    private void OnDisable()
    {
        _spawner.EnemiesEnded -= EndGame;
    }
}
