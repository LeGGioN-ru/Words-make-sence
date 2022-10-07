using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class GameStarter : MonoBehaviour
{
    private Button _startGameButton;

    private void Awake()
    {
        _startGameButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _startGameButton.onClick.AddListener(OnStartGameButtonClick);
    }

    private void OnDisable()
    {
        _startGameButton.onClick.RemoveListener(OnStartGameButtonClick);
    }

    private void OnStartGameButtonClick()
    {
        TestGame.Load();
    }
}
