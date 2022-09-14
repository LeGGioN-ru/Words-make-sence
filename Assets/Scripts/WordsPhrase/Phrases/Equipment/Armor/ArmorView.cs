public class ArmorView : EquipmentView
{
    protected override void OnEnable()
    {
        Player.ArmorChanged += OnEquipmentChanged;
    }

    protected override void OnDisable()
    {
        Player.ArmorChanged -= OnEquipmentChanged;
    }
}
