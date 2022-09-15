using UnityEngine;

[CreateAssetMenu(fileName = "new Armor", menuName = "Equipment/Armor", order = 51)]
public class Armor : Equipment
{
    [SerializeField] private int _defendPercent;
    [SerializeField] private int _healthRegeneration;
    [SerializeField] private int _manaRegeneration;

    public int DefendPercent => _defendPercent;
    public float HealthRegeneration => _healthRegeneration;
    public float ManaRegeneration => _manaRegeneration;
}
