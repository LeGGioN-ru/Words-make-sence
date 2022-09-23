using System;
using UnityEngine;

public class ArmorHolder : EquipmentHolder
{
    [SerializeField] private Armor _armor;

    public Armor Armor => _armor;

    protected override void Start()
    {
        OnChanged(_armor);
        base.Start();
    }

    protected override void OnChanged(Equipment equipment)
    {
        if (equipment is Armor armor)
        {
            _armor = armor;
            base.OnChanged(equipment);
        }

    }

    public int CalculateDamage(int damage)
    {
        int maxPercent = 100;
        int finalDamage = damage;

        if (_armor != null)
            finalDamage = Convert.ToInt32(Convert.ToSingle(damage) / maxPercent * (maxPercent - _armor.DefendPercent));

        return finalDamage;
    }
}
