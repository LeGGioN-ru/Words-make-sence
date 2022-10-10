using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class EquipmentView : MonoBehaviour
{
    [SerializeField] private EquipmentHolder _holder;
    private Image _image;

    private void OnEnable()
    {
        _holder.Changed += OnChanged;
    }

    private void OnDisable()
    {
        _holder.Changed -= OnChanged;
    }

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void OnChanged(Equipment equipment)
    {
        _image.sprite = equipment.Icon;
    }
}
