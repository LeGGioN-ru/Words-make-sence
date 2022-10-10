using UnityEngine;
using UnityEngine.Events;

public class WordsPhraseTranslator : MonoBehaviour
{
    [SerializeField] private WordChecker _wordChecker;
    [SerializeField] private Phrase[] _phrases;
    [SerializeField] private ItemViewsGenerator _itemViewsGenerator;

    public event UnityAction<Phrase> Translated;
    public event UnityAction Checked;
    public event UnityAction Canceled;
    public event UnityAction Cleared;

    private FirstOrderWord _firstOrderWord;

    private void OnEnable()
    {
        _itemViewsGenerator.Init(_phrases);
        _wordChecker.Init(_phrases);
        _wordChecker.WordApproved += OnWordApproved;
    }

    private void OnDisable()
    {
        _wordChecker.WordApproved -= OnWordApproved;
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

        CancelWords();
    }

    private void TryActivateWord(SecondOrderWord secondOrderWord)
    {
        foreach (var phrase in _phrases)
        {
            if (phrase.Compare(_firstOrderWord, secondOrderWord))
            {
                Checked?.Invoke();
                Translated?.Invoke(phrase);
                ClearWords();
                return;
            }
        }

        CancelWords();
    }

    private void ClearWords()
    {
        Cleared?.Invoke();
        _firstOrderWord = null;
    }

    private void CancelWords()
    {
        Canceled?.Invoke();
        _firstOrderWord = null;
    }
}
