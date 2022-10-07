using UnityEngine;

public abstract class Phrase : ScriptableObject
{
    [SerializeField] private FirstOrderWord _firstOrderWord;
    [SerializeField] private SecondOrderWord _secondOrderWord;
    [SerializeField] private int _apptembsToActivate;
    [SerializeField] private Sprite _icon;


    public FirstOrderWord FirstOrderWord => _firstOrderWord;
    public SecondOrderWord SecondOrderWord => _secondOrderWord;
    public Sprite Icon => _icon;
    public string Title => _firstOrderWord.Label + " " + _secondOrderWord.Label;
    public int ApptembsToActivate => _apptembsToActivate;

    public bool Compare(FirstOrderWord firstOrderWord, SecondOrderWord secondOrderWord)
    {
        if (_firstOrderWord.Equals(firstOrderWord) && _secondOrderWord.Equals(secondOrderWord))
        {
            return true;
        }

        return false;
    }
}
