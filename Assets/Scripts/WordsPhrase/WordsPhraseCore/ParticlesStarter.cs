using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WordsPhraseTranslator))]
public class ParticlesStarter : MonoBehaviour
{
    [SerializeField] private ParticleSystem _translatedParticle;
    [SerializeField] private ParticleSystem _canceledParticle;

    private WordsPhraseTranslator _translator;

    private void Awake()
    {
        _translator = GetComponent<WordsPhraseTranslator>();
    }

    private void OnEnable()
    {
        _translator.Canceled += OnCanceled;
        _translator.Translated += OnTranslated;
    }

    private void OnDisable()
    {
        _translator.Canceled -= OnCanceled;
        _translator.Translated -= OnTranslated;
    }

    private void OnTranslated(Phrase phrase)
    {
        _translatedParticle.Play();
    }

    private void OnCanceled()
    {
        _canceledParticle.Play();
    }
}
