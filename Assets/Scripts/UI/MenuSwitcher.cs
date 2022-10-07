using UnityEngine;
using UnityEngine.UI;

public class MenuSwitcher : CanvasGroupSwitcher
{
    [SerializeField] private Button _closeButton;

    private PlayerInput _playerInput;

    protected override void Awake()
    {
        _playerInput = new PlayerInput();
        base.Awake();
    }

    private void OnEnable()
    {
        _closeButton.onClick.AddListener(OnButtonClick);
        _playerInput.Enable();
        _playerInput.Player.SwitchMenu.performed += ctx => OnButtonClick();
    }

    private void OnDisable()
    {
        _closeButton.onClick.RemoveListener(OnButtonClick);
        _playerInput.Player.SwitchMenu.performed -= ctx => OnButtonClick();
        _playerInput.Disable();
    }
}
