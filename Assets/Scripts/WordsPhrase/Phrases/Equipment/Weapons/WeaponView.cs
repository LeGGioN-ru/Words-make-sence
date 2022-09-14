public class WeaponView : EquipmentView
{
    protected override void OnDisable()
    {
        Player.WeaponChanged -= OnEquipmentChanged;
    }

    protected override void OnEnable()
    {
        Player.WeaponChanged += OnEquipmentChanged;
    }
}
