using System;
using UnityEngine;

public class ArmorHolder : EquipmentHolder
{
    [SerializeField] private Armor _armor;

    public Armor Armor => _armor;

    private int _regenerationDelay = 5;
    private float _passedTime;

    protected override void Start()
    {
        OnChanged(_armor);
    }

    private void Update()
    {
        if (_armor == null)
            return;

        if (_passedTime >= _regenerationDelay)
        {
            Fighter.Heal(_armor.HealthRegeneration);
            Fighter.HealMana(_armor.ManaRegeneration);
            _passedTime = 0;
        }

        _passedTime += Time.deltaTime;
    }

    protected override void OnChanged(Equipment equipment)
    {
        if (equipment is Armor armor)
        {
            _armor = armor;
            Fighter.SetStats(armor);
            base.OnChanged(equipment);
        }
    }

    public void CalculateDamage(int damage)
    {
        int maxPercent = 100;
        int finalDamage = damage;

        if (_armor != null)
            finalDamage = Convert.ToInt32(Convert.ToSingle(damage) / maxPercent * (maxPercent - _armor.DefendPercent));

        Fighter.TakeDamage(finalDamage);
    }
}
