using UnityEngine;
using UnityEngine.UI;

public class LetterPanelCleanerView : MonoBehaviour
{
    [SerializeField] private LetterPanelCleaner _letterPanelCleaner;
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
        _icon.fillAmount = value;
    }
}
