using UnityEngine;
using UnityEngine.UI;

public class LetterPanelCleanerView : MonoBehaviour
{
    [SerializeField] private LetterPanelCleaner _letterPanelCleaner;
    [SerializeField] private float _roundingThreshold;
    [SerializeField] private Image _icon;

    private void OnEnable()
    {
        _letterPanelCleaner.TimePassed += OnTimePassed;
    }

    private void OnDisable()
    {
        _letterPanelCleaner.TimePassed -= OnTimePassed;
    }

    private void OnTimePassed(float passedTime, float cooldown)
    {
        var value = passedTime / cooldown;
        float maxValue = 1;

        if (value >= _roundingThreshold)
            value = maxValue;

        _icon.fillAmount = value;
    }
}
