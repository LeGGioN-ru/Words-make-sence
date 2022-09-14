using UnityEngine;

public class Word : ScriptableObject
{
    [SerializeField] private string _label;

    public string Label => _label;
}
