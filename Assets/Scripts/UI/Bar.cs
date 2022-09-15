using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Player Player;

    private Slider _bar;

    private void Awake()
    {
        _bar = GetComponent<Slider>();
    }

    protected abstract void OnEnable();
    protected abstract void OnDisable();

    protected void OnChange(int value, int maxValue)
    {
        float maxPercent = 100;
        float currentPercent = value / (maxValue / maxPercent) / maxPercent;
        _bar.value = currentPercent;
    }
}
