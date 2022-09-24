using UnityEngine;

public class Enemy : Fighter
{
    [SerializeField] private string _name;

    public string Name => _name;
}
