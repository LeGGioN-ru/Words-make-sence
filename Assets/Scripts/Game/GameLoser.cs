using IJunior.TypedScenes;
using UnityEngine;

public class GameLoser : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.Died += OnDied;
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
    }

    private void OnDied()
    {
        _animator.Play(EndGameAnimationController.States.Lose);
    }

    private void StartMainMenu()
    {
        MainMenu.Load();
    }
}
