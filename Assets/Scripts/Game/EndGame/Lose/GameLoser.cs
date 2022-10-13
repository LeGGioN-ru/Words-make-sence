using UnityEngine;

[RequireComponent(typeof(Player))]
public class GameLoser : GameEnder
{
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _player.Died += EndGame;
    }

    private void OnDisable()
    {
        _player.Died -= EndGame;
    }
}
