public class WordPediaSwitcher : CanvasGroupSwitcher
{
    private PlayerInput _playerInput;

    protected override void Awake()
    {
        PlayerInput playerInput = new PlayerInput();
        _playerInput = playerInput;
        base.Awake();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
        _playerInput.Player.SwitchWordPedia.performed += ctx => OnButtonClick();
    }

    private void OnDisable()
    {
        _playerInput.Player.SwitchWordPedia.performed -= ctx => OnButtonClick();
        _playerInput.Disable();
    }
}
