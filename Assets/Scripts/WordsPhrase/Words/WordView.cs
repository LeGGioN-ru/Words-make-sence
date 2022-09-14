using TMPro;
using UnityEngine;

public class WordView : MonoBehaviour
{
    [SerializeField] private LetterWallet _letterWallet;
    [SerializeField] private TMP_Text[] _typeFields;
    [SerializeField] private WordChecker _typedWordChecker;
    [SerializeField] private WordsPhraseTranslator _wordsPhraseTranslator;

    private int _currentTypeFieldIndex;
    private bool _isNewTypeField;

    private void OnEnable()
    {
        _letterWallet.Changed += OnChanged;
        _wordsPhraseTranslator.Translated += OnTranslated;
        _typedWordChecker.WordApproved += OnWordApproved;
    }

    private void OnDisable()
    {
        _letterWallet.Changed -= OnChanged;
        _wordsPhraseTranslator.Translated -= OnTranslated;
        _typedWordChecker.WordApproved -= OnWordApproved;
    }

    private void OnTranslated(Phrase endWord)
    {
        _currentTypeFieldIndex = 0;

        foreach (var typeField in _typeFields)
        {
            typeField.text = string.Empty;
        }
    }

    private void OnWordApproved(Word word)
    {
        OnChanged(word.Label);

        if (_currentTypeFieldIndex + 1 < _typeFields.Length)
            _currentTypeFieldIndex++;

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
