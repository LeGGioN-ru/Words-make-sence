using UnityEngine;
using UnityEngine.Events;

public class Letter : MonoBehaviour
{
    public event UnityAction<char> Changed;

    public char Label { get; private set; }

    private void Start()
    {
        ChangeLabel();
    }

    public void ChangeLabel()
    {
        Label = Alphabet.GetRandomLetter();
        Changed?.Invoke(Label);
    }
}
