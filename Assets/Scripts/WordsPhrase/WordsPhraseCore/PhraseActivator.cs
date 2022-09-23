using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhraseActivator : MonoBehaviour
{
    [SerializeField] private WordsPhraseTranslator _wordsPhraseTranslator;
    [SerializeField] private Player _player;
    [SerializeField] private PhraseApptembsView _template;
    [SerializeField] private Transform _container;

    public event UnityAction<Phrase> Activated;
    public event UnityAction<Phrase, int> ApptembsIncreased;

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
            AddPhrase(phrase);
        }

        _phrasesApptembs[phrase]++;
        ApptembsIncreased?.Invoke(phrase, _phrasesApptembs[phrase]);

        if (_phrasesApptembs[phrase] >= phrase.ApptembsToActivate)
        {
            Activated?.Invoke(phrase);
            _phrasesApptembs.Remove(phrase);
        }
    }

    private void AddPhrase(Phrase phrase)
    {
        _phrasesApptembs.Add(phrase, 0);
        var apptembsView = Instantiate(_template, _container);
        apptembsView.Init(this, phrase);
    }
}
