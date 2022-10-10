using UnityEngine;

public class WordPediaSwitcher : CanvasGroupSwitcher
{
    [SerializeField] private MenuSwitcher _menuSwitcher;

    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
        _playerInput.Player.SwitchWordPedia.performed += ctx => OnButtonClick();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _playerInput.Player.SwitchWordPedia.performed -= ctx => OnButtonClick();
        _playerInput.Disable();
    }

    protected override void Hide()
    {
        if (_menuSwitcher != null)
            _menuSwitcher.enabled = true;

        base.Hide();
    }

    protected override void Show()
    {
        if (_menuSwitcher != null)
            _menuSwitcher.enabled = false;

        base.Show();
    }
}
