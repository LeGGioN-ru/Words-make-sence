using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class LetterPanelCleaner : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _cooldownIncrease;
    [SerializeField] private float _roundValue;

    public event UnityAction<float, float> TimePassed;

    private List<LetterView> _letterViews;
    private float _passedTime;

    public void Init(List<LetterView> letterViews)
    {
        _letterViews = letterViews;

        _playerInput = new PlayerInput();
        _playerInput.Enable();
        _playerInput.Player.ClearLetterPanel.performed += ctx => OnLetterPanelClear();
        _passedTime = _cooldown;
    }

    private void OnDisable()
    {
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
            _passedTime = 0;
            _cooldown += _cooldownIncrease;
            _letterViews.Where(letter => letter.IsSelected == false).ToList().ForEach(letter => letter.Letter.ChangeLabel());
        }
    }
}
