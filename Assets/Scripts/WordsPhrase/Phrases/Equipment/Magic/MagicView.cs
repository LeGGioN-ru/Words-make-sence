public class MagicView : EquipmentView
{
    protected override void OnEnable()
    {
        Player.MagicChanged += OnEquipmentChanged;
    }

    protected override void OnDisable()
    {
        Player.MagicChanged -= OnEquipmentChanged;
    }
}
