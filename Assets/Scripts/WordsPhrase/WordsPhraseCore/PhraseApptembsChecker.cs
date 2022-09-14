using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhraseApptembsChecker : MonoBehaviour
{
    [SerializeField] private WordsPhraseTranslator _wordsPhraseTranslator;
    [SerializeField] private Player _player;

    public event UnityAction<Phrase> PhraseApproved;

    private Dictionary<Phrase, int> _phrasesApptembs = new Dictionary<Phrase, int>();

    private void OnEnable()
    {
        _wordsPhraseTranslator.Translated += OnTranslated;
    }

    private void OnDisable()
    {
        _wordsPhraseTranslator.Translated -= OnTranslated;
    }

    public void OnTranslated(Phrase phrase)
    {
        if (_phrasesApptembs.ContainsKey(phrase) == false)
        {
            _phrasesApptembs.Add(phrase, 0);
        }

        _phrasesApptembs[phrase]++;

        if (_phrasesApptembs[phrase] >= phrase.ApptembsToActivate)
        {
            PhraseApproved?.Invoke(phrase);
            _phrasesApptembs.Remove(phrase);
        }
    }
}
