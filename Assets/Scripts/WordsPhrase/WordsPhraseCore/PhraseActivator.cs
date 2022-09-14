using UnityEngine;
using UnityEngine.Events;

public class PhraseActivator : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PhraseApptembsChecker _phraseApptembsChecker;

    private void OnEnable()
    {
        _phraseApptembsChecker.PhraseApproved += OnPhraseApproved;
    }

    private void OnDisable()
    {
        _phraseApptembsChecker.PhraseApproved -= OnPhraseApproved;
    }

    private void OnPhraseApproved(Phrase phrase)
    {
        switch (phrase)
        {
            case Weapon weapon:
                _player.EquipWeapon(weapon);
                break;
        }
    }
}
