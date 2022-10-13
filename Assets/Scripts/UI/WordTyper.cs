using TMPro;
using UnityEngine;

public class WordTyper : MonoBehaviour
{
    [SerializeField] private LetterWallet _letterWallet;
    [SerializeField] private TMP_Text[] _typeFields;
    [SerializeField] private WordChecker _typedWordChecker;
    [SerializeField] private WordsPhraseTranslator _wordsPhraseTranslator;

    private int _currentTypeFieldIndex;
    private bool _isNewTypeField;

    private void OnEnable()
    {
        _wordsPhraseTranslator.Canceled += ClearWords;
        _wordsPhraseTranslator.Cleared += ClearWords;
        _typedWordChecker.WordApproved += OnWordApproved;
        _letterWallet.Changed += OnChanged;
    }

    private void OnDisable()
    {
        _wordsPhraseTranslator.Canceled -= ClearWords;
        _wordsPhraseTranslator.Cleared -= ClearWords;
        _typedWordChecker.WordApproved -= OnWordApproved;
        _letterWallet.Changed -= OnChanged;
    }

    private void ClearWords()
    {
        _isNewTypeField = true;
        _currentTypeFieldIndex = 0;

        foreach (var typeField in _typeFields)
        {
            typeField.text = string.Empty;
        }
    }

    private void OnWordApproved(Word word)
    {
        _typeFields[_currentTypeFieldIndex].text = word.Label;

        if (_currentTypeFieldIndex < _typeFields.Length - 1)
            _currentTypeFieldIndex++;

        _typeFields[_currentTypeFieldIndex].text = string.Empty;
        _isNewTypeField = true;
    }

    private void OnChanged(string word)
    {
        if (_isNewTypeField)
        {
            _isNewTypeField = false;
            return;
        }

        _typeFields[_currentTypeFieldIndex].text = word;
    }
}
