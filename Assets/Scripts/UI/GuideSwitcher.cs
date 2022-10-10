using UnityEngine;
using UnityEngine.UI;

public class GuideSwitcher : CanvasGroupSwitcher
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _openButton;

    private void OnEnable()
    {
        _openButton.onClick.AddListener(Show);
        _closeButton.onClick.AddListener(Hide);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _openButton.onClick.RemoveListener(Show);
        _closeButton.onClick.RemoveListener(Hide);
    }
}
