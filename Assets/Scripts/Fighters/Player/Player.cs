using System;
using UnityEngine.Events;

public class Player : Fighter
{
    private int _additionalHealth;
    private int _additionalMana;

    public void IncreaseHealth(int health)
    {
        _additionalHealth += health;
        MaxHealth += _additionalHealth;
    }

    public void DecreaseHealth(int health)
    {
        _additionalHealth -= health;
        MaxHealth -= _additionalHealth;
    }

    public void IncreaseMana(int mana)
    {
        _additionalMana += mana;
        MaxMana += _additionalMana;
    }

    public void DecreaseMana(int mana)
    {
        _additionalMana -= mana;
        MaxMana -= _additionalMana;
    }

    public void SetStats(Armor armor)
    {
        MaxHealth = armor.Health + _additionalHealth;
        MaxMana = armor.Mana + _additionalMana;
        Heal(MaxHealth - CurrentHealth);
        RecoverMana(MaxMana - CurrentMana);
    }
}
