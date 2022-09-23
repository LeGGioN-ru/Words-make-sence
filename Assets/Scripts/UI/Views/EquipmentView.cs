using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class EquipmentView : MonoBehaviour
{
    [SerializeField] private EquipmentHolder _holder;
    private Image _image;

    private void OnEnable()
    {
        _holder.Equip += OnEquipmentChanged;
    }

    private void OnDisable()
    {
        _holder.Equip -= OnEquipmentChanged;
    }

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void OnEquipmentChanged(Equipment equipment)
    {
        _image.sprite = equipment.Icon;
    }
}
