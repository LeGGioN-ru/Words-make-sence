using System;
using UnityEngine;

public class ArmorHolder : EquipmentHolder
{
    [SerializeField] private Armor _armor;

    public Armor Armor => _armor;

    private readonly int _regenerationDelay = 5;
    private float _passedTime;

    protected override void Start()
    {
        OnActivated(_armor);
    }

    private void Update()
    {
        if (_passedTime >= _regenerationDelay)
        {
            Regenerate();
            _passedTime = 0;
        }

        _passedTime += Time.deltaTime;
    }

    public void CalculateDamage(int damage)
    {
        int maxPercent = 100;
        int finalDamage = damage;

        if (_armor != null)
            finalDamage = Convert.ToInt32(Convert.ToSingle(damage) / maxPercent * (maxPercent - _armor.DefendPercent));

        Fighter.TakeDamage(finalDamage);
    }

    private void Regenerate()
    {
        if (_armor == null)
        {
            Fighter.Heal(0);
            Fighter.RecoverMana(0);
            return;
        }

        int healthAfterRegeneration = _armor.HealthRegeneration + Fighter.CurrentHealth;

        if (healthAfterRegeneration <= Fighter.MaxHealth)
            Fighter.Heal(_armor.HealthRegeneration);

        int manaAfterRegeneration = _armor.ManaRegeneration + Fighter.CurrentMana;

        if (manaAfterRegeneration <= Fighter.MaxMana)
            Fighter.RecoverMana(_armor.ManaRegeneration);
    }

    protected override void OnActivated(Phrase phrase)
    {
        if (phrase is Armor armor && Fighter is Player player)
        {
            _armor = armor;
            player.SetStats(armor);
            Change(armor);
        }
    }
}
