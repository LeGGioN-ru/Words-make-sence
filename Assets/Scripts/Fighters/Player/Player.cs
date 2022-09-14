using UnityEngine.Events;

public class Player : Fighter
{
    public event UnityAction<Equipment> WeaponChanged;
    public event UnityAction<Equipment> ArmorChanged;
    public event UnityAction<Equipment> MagicChanged;

    public void EquipWeapon(Weapon weapon)
    {
        CurrentWeapon = weapon;
        WeaponChanged?.Invoke(weapon);
    }

    public void EquipArmor(Armor armor)
    {
        CurrentArmor = armor;
        ArmorChanged?.Invoke(armor);
    }

    public void EquipMagic(Magic magic)
    {
        CurrentMagic = magic;
        MagicChanged?.Invoke(magic);
    }
}
