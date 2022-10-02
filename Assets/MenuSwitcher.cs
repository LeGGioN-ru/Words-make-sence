using UnityEngine;

public class MenuSwitcher : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;

    private PlayerInput _playerInput;
    private bool _isVisible = true;

    private void Start()
    {
        PlayerInput playerInput = new PlayerInput();
        _playerInput = playerInput;

        playerInput.Enable();
        playerInput.Player.SwitchMenu.performed += ctx => OnButtonMenuSwitchPress();
    }

    private void OnDisable()
    {
        _playerInput.Player.SwitchMenu.performed -= ctx => OnButtonMenuSwitchPress();
        _playerInput.Disable();
    }

    private void OnButtonMenuSwitchPress()
    {
        _isVisible = !_isVisible;

        if (_isVisible)
        {
            DisableMenu();
            return;
        }

        EnableMenu();
    }

    private void EnableMenu()
    {
        Time.timeScale = 0;
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
    }

    private void DisableMenu()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
        Time.timeScale = 1;
    }
}
