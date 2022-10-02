using System;
using UnityEngine;
using UnityEngine.Events;

public class WordsPhraseTranslator : MonoBehaviour
{
    [SerializeField] private WordChecker _typedWordChecker;
    [SerializeField] private Phrase[] _endedWords;
    [SerializeField] private ItemViewsGenerator _itemViewsGenerator;

    public event UnityAction<Phrase> Translated;
    public event UnityAction Checked;
    public event UnityAction WordCanceled;

    private FirstOrderWord _firstOrderWord;

    private void OnEnable()
    {
        _itemViewsGenerator.Init(_endedWords);
        _typedWordChecker.WordApproved += OnWordApproved;
    }

    private void OnDisable()
    {
        _typedWordChecker.WordApproved -= OnWordApproved;
    }

    private void OnWordApproved(Word word)
    {
        switch (word)
        {
            case FirstOrderWord firstOrderWord:
                TryAddFirstOrderWord(firstOrderWord);
                break;

            case SecondOrderWord secondOrderWord:
                TryActivateWord(secondOrderWord);
                break;
        }
    }

    private void TryAddFirstOrderWord(FirstOrderWord firstOrderWord)
    {
        if (_firstOrderWord == null)
        {
            _firstOrderWord = firstOrderWord;
            Checked?.Invoke();
            return;
        }

        CleanWords();
    }

    private void TryActivateWord(SecondOrderWord secondOrderWord)
    {
        foreach (var endWord in _endedWords)
        {
            if (endWord.Compare(_firstOrderWord, secondOrderWord))
            {
                Checked?.Invoke();
                Translated?.Invoke(endWord);
            }
        }

        CleanWords();
    }

    private void CleanWords()
    {
        WordCanceled?.Invoke();
        _firstOrderWord = null;
    }
}
