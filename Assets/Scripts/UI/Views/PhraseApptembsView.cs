using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PhraseApptembsView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _text;

    private PhraseActivator _phraseActivator;
    private Phrase _phrase;

    public void Init(PhraseActivator phraseActivator, Phrase phrase)
    {
        _phraseActivator = phraseActivator;
        _phrase = phrase;
        _image.sprite = phrase.Icon;

        OnApptembsIncreased(phrase, 0);
        _phraseActivator.ApptembsIncreased += OnApptembsIncreased;
        _phraseActivator.Activated += OnActivated;
    }

    private void OnDisable()
    {
        _phraseActivator.ApptembsIncreased -= OnApptembsIncreased;
        _phraseActivator.Activated -= OnActivated;
    }

    private void OnApptembsIncreased(Phrase phrase, int apptembs)
    {
        if (_phrase.Equals(phrase) == false)
            return;

        _slider.value = Convert.ToSingle(apptembs) / _phrase.ApptembsToActivate;
        _text.text = $"{apptembs}/{phrase.ApptembsToActivate}";
    }

    private void OnActivated(Phrase phrase)
    {
        if (_phrase.Equals(phrase))
            Destroy(gameObject);
    }
}
