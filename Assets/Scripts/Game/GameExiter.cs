using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class GameExiter : MonoBehaviour
{
    private Button _exitButton;

    private void Awake()
    {
        _exitButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}
