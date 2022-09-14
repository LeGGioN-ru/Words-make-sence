using UnityEngine;

public abstract class Phrase : ScriptableObject
{
    [SerializeField] private FirstOrderWord _firstOrderWord;
    [SerializeField] private SecondOrderWord _secondOrderWord;
    [SerializeField] private int _apptembsToActivate;

    public string Title => _firstOrderWord.Label + " " + _secondOrderWord.Label;
    public int ApptembsToActivate => _apptembsToActivate;

    public bool Compare(FirstOrderWord firstCreativeWord, SecondOrderWord secondOrderWord)
    {
        if (_firstOrderWord.Label == firstCreativeWord.Label && _secondOrderWord.Label == secondOrderWord.Label)
        {
            return true;
        }

        return false;
    }
}
