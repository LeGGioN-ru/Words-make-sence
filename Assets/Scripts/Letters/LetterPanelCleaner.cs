using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class LetterPanelCleaner : MonoBehaviour
{
    [SerializeField] private WordPediaSwitcher _wordPediaSwitcher;
    [SerializeField] private MenuSwitcher _menuSwitcher;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _cooldownIncrease;
    [SerializeField] private float _roundValue;
    [SerializeField] private AudioSource _clearSound;

    public event UnityAction<float, float> TimePassed;

    private PlayerInput _playerInput;
    private LetterView[] _letterViews;
    private float _passedTime;

    public void Init(LetterView[] letterViews)
    {
        _letterViews = letterViews;

        _playerInput = new PlayerInput();
        _playerInput.Enable();
        _playerInput.Player.ClearLetterPanel.performed += ctx => OnLetterPanelClear();
        _passedTime = _cooldown;
    }

    private void OnEnable()
    {
        _wordPediaSwitcher.Showed += OnShowed;
        _menuSwitcher.Showed += OnShowed;
        _wordPediaSwitcher.Hided += OnHided;
        _menuSwitcher.Hided += OnHided;
    }

    private void OnDisable()
    {
        _wordPediaSwitcher.Showed -= OnShowed;
        _menuSwitcher.Showed -= OnShowed;
        _wordPediaSwitcher.Hided -= OnHided;
        _menuSwitcher.Hided -= OnHided;

        _playerInput.Disable();
        _playerInput.Player.ClearLetterPanel.performed -= ctx => OnLetterPanelClear();
    }

    private void Update()
    {
        _passedTime += Time.deltaTime;

        if (_passedTime > _cooldown + _roundValue)
            return;

        TimePassed?.Invoke(_passedTime, _cooldown);
    }

    private void OnLetterPanelClear()
    {
        if (_passedTime >= _cooldown)
        {
            _clearSound.Play();
            _passedTime = 0;
            _cooldown += _cooldownIncrease;
            _letterViews.Where(letter => letter.IsSelected == false).ToList().ForEach(letter => letter.Letter.ChangeLabel());
        }
    }

    private void OnShowed()
    {
        _playerInput.Disable();
    }

    private void OnHided()
    {
        _playerInput.Enable();
    }
}
