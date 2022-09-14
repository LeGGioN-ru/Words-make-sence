using UnityEngine;
using UnityEngine.Events;

public class WordsPhraseTranslator : MonoBehaviour
{
    [SerializeField] private WordChecker _typedWordChecker;
    [SerializeField] private Phrase[] _endedWords;

    public event UnityAction<Phrase> Translated;
    public event UnityAction WordCanceled;

    private FirstOrderWord _firstOrderWord;

    private void OnEnable()
    {
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
            return;
        }

        CancelWord();
    }

    private void TryActivateWord(SecondOrderWord secondOrderWord)
    {
        foreach (var endWord in _endedWords)
        {
            if (endWord.Compare(_firstOrderWord, secondOrderWord))
            {
                Translated?.Invoke(endWord);
                return;
            }
        }

        CancelWord();
    }

    private void CancelWord()
    {
        WordCanceled?.Invoke();
        _firstOrderWord = null;
    }
}
