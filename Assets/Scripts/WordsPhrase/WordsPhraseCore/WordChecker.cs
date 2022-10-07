using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class WordChecker : MonoBehaviour
{
    [SerializeField] private LetterWallet _letterWallet;

    public event UnityAction<Word> WordApproved;

    private List<Word> _wordPool = new List<Word>();

    public void Init(Phrase[] phrases)
    {
        foreach (var phrase in phrases)
        {
            if (_wordPool.Contains(phrase.FirstOrderWord) == false)
                _wordPool.Add(phrase.FirstOrderWord);

            if (_wordPool.Contains(phrase.SecondOrderWord) == false)
                _wordPool.Add(phrase.SecondOrderWord);
        }
    }

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
        var definedWord = _wordPool.FirstOrDefault(word => word.Label == currentWord);

        if (definedWord != null)
            WordApproved?.Invoke(definedWord);
    }
}
