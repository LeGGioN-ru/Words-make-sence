using UnityEngine;

[CreateAssetMenu(fileName = "new Armor", menuName = "Equipment/Armor", order = 51)]
public class Armor : Equipment
{
    [SerializeField] private int _defendPercent;
    [SerializeField] private int _healthRegeneration;
    [SerializeField] private int _manaRegeneration;
    [SerializeField] private int _health;
    [SerializeField] private int _mana;

    public int DefendPercent => _defendPercent;
    public int HealthRegeneration => _healthRegeneration;
    public int ManaRegeneration => _manaRegeneration;
    public int Health => _health;
    public int Mana => _mana;
}
