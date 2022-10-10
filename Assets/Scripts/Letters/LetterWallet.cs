using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class LetterWallet : MonoBehaviour
{
    [SerializeField] private WordsPhraseTranslator _wordsPhraseTranslator;

    public event UnityAction<string> Changed;

    private List<Letter> _selectedLetters;
    private LetterView[] _letterViews;
    private PlayerInput _playerInput;

    public string CurrentWord
    {
        get
        {
            string word = string.Empty;

            foreach (var letter in _selectedLetters)
            {
                word += letter.Label;
            }

            return word;
        }
    }

    public void Init(LetterView[] letterViews)
    {
        _letterViews = letterViews;

        foreach (var letter in _letterViews)
            letter.Clicked += OnClick;

        _wordsPhraseTranslator.Checked += OnWordApprove;
        _wordsPhraseTranslator.Canceled += ClearLetters;
        _wordsPhraseTranslator.Cleared += ClearLetters;
    }

    private void OnDisable()
    {
        _playerInput.Player.ClearLetters.performed -= ctx => OnClearButtonPress();
        _playerInput.Disable();

        foreach (var letter in _letterViews)
            letter.Clicked -= OnClick;

        _wordsPhraseTranslator.Checked -= OnWordApprove;
        _wordsPhraseTranslator.Canceled -= ClearLetters;
        _wordsPhraseTranslator.Cleared -= ClearLetters;
    }

    private void Start()
    {
        _selectedLetters = new List<Letter>();
        _playerInput = new PlayerInput();
        _playerInput.Enable();
        _playerInput.Player.ClearLetters.performed += ctx => OnClearButtonPress();
    }

    private void OnClick(Letter letter)
    {
        if (_selectedLetters.FirstOrDefault(let => let == letter) != null)
        {
            _selectedLetters.Remove(letter);
        }
        else
        {
            _selectedLetters.Add(letter);
        }

        Changed?.Invoke(CurrentWord);
    }

    private void OnWordApprove()
    {
        _selectedLetters.ForEach(let => let.ChangeLabel());

        _selectedLetters.Clear();
    }

    private void OnClearButtonPress()
    {
        ClearLetters();
        Changed?.Invoke(string.Empty);
    }

    private void ClearLetters()
    {
        _selectedLetters.Clear();

        foreach (var letter in _letterViews)
        {
            letter.DeSelect();
        }
    }
}
