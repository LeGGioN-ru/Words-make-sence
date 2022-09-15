using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class LetterWallet : MonoBehaviour
{
    [SerializeField] private WordChecker _typedWordChecker;
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
        {
            letter.Clicked += OnClick;
        }

        _typedWordChecker.WordApproved += OnWordApprove;
        _wordsPhraseTranslator.WordCanceled += ClearLetters;
    }

    private void OnDisable()
    {
        _playerInput.Disable();

        foreach (var letter in _letterViews)
            letter.Clicked -= OnClick;

        _typedWordChecker.WordApproved -= OnWordApprove;
        _wordsPhraseTranslator.WordCanceled -= ClearLetters;
    }

    private void Start()
    {
        _selectedLetters = new List<Letter>();
        _playerInput = new PlayerInput();
        _playerInput.Enable();
        _playerInput.Player.ClearLetters.performed += ctx => ClearLetters();
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

    private void OnWordApprove(Word word)
    {
        foreach (var letter in _selectedLetters)
        {
            letter.ChangeLabel();
        }

        _selectedLetters.Clear();
    }

    private void ClearLetters()
    {
        foreach (var letter in _letterViews)
        {
            letter.DeSelect();
        }

        _selectedLetters.Clear();

        Changed?.Invoke(CurrentWord);
    }
}
