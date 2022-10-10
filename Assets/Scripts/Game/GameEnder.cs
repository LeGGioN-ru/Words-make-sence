using UnityEngine;

public class GameEnder : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private MenuSwitcher _menuSwitcher;
    [SerializeField] private WordPediaSwitcher _wordPediaSwitcher;

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
        _menuSwitcher.enabled = false;
        _wordPediaSwitcher.enabled = false;
    }
}
