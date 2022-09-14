using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public abstract class EquipmentView : MonoBehaviour
{
    [SerializeField] protected Player Player;

    private Image _image;

    protected abstract void OnEnable();
    protected abstract void OnDisable();

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void OnEquipmentChanged(Equipment equipment)
    {
        _image.sprite = equipment.Icon;
    }
}
