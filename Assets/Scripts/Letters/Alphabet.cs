using System;

[Serializable]
public static class Alphabet
{
    private static readonly char[] _alphabet = "�����������������������������".ToCharArray();

    public static char GetRandomLetter()
    {
        return _alphabet[UnityEngine.Random.Range(0, _alphabet.Length)];
    }
}
