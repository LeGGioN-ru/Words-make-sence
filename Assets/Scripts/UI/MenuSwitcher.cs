using UnityEngine;
using UnityEngine.UI;

public class MenuSwitcher : CanvasGroupSwitcher
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private WordPediaSwitcher _wordPediaSwitcher;

    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        _closeButton.onClick.AddListener(OnButtonClick);
        _playerInput.Enable();
        _playerInput.Player.SwitchMenu.performed += ctx => OnButtonClick();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _closeButton.onClick.RemoveListener(OnButtonClick);
        _playerInput.Player.SwitchMenu.performed -= ctx => OnButtonClick();
        _playerInput.Disable();
    }

    protected override void Hide()
    {
        if (_wordPediaSwitcher != null)
            _wordPediaSwitcher.enabled = true;

        base.Hide();
    }

    protected override void Show()
    {
        if (_wordPediaSwitcher != null)
            _wordPediaSwitcher.enabled = false;
        
        base.Show();
    }
}
