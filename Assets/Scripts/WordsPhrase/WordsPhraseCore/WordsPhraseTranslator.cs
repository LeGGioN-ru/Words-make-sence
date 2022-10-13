using UnityEngine;
using UnityEngine.Events;

public class WordsPhraseTranslator : MonoBehaviour
{
    [SerializeField] private WordChecker _wordChecker;
    [SerializeField] private Phrase[] _phrases;
    [SerializeField] private ItemViewsGenerator _itemViewsGenerator;
    [SerializeField] private AudioSource _cancelSound;
    [SerializeField] private AudioSource _translateSound;

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
                TryExecute(secondOrderWord);
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

    private void TryExecute(SecondOrderWord secondOrderWord)
    {
        foreach (var phrase in _phrases)
        {
            if (phrase.Compare(_firstOrderWord, secondOrderWord))
            {
                Execute(phrase);
                return;
            }
        }

        CancelWords();
    }

    private void Execute(Phrase phrase)
    {
        Checked?.Invoke();
        Translated?.Invoke(phrase);
        _translateSound.Play();
        ClearWords();
    }

    private void ClearWords()
    {
        Cleared?.Invoke();
        _firstOrderWord = null;
    }

    private void CancelWords()
    {
        _cancelSound.Play();
        Canceled?.Invoke();
        _firstOrderWord = null;
    }
}
