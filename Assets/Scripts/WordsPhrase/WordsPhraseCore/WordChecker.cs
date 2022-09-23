using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class WordChecker : MonoBehaviour
{
    [SerializeField] private Word[] _wordPool;
    [SerializeField] private LetterWallet _letterWallet;

    public event UnityAction<Word> WordApproved;

    private void OnEnable()
    {
        _letterWallet.Changed += OnChanged;
    }

    private void OnDisable()
    {
        _letterWallet.Changed -= OnChanged;
    }

    private void OnChanged(string currentWord)
    {
        var definedWord = _wordPool.FirstOrDefault(word => word.Label.ToUpper() == currentWord.ToUpper());

        if (definedWord != null)
        {
            WordApproved?.Invoke(definedWord);
        }
    }
}
