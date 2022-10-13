using UnityEngine;

public abstract class GameEnder : MonoBehaviour
{
    [SerializeField] private MenuSwitcher _menuSwitcher;
    [SerializeField] private WordPediaSwitcher _wordPediaSwitcher;
    [SerializeField] private EndScreen _endScreen;

    protected virtual void EndGame()
    {
        _menuSwitcher.gameObject.SetActive(false);
        _wordPediaSwitcher.gameObject.SetActive(false);
        Instantiate(_endScreen);
    }
}
