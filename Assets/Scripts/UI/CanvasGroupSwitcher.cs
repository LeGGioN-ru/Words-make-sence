using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public abstract class CanvasGroupSwitcher : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    private bool _isVisible;

    protected virtual void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    protected void OnButtonClick()
    {
        _isVisible = !_isVisible;

        if (_isVisible)
        {
            Show();
            return;
        }

        Hide();
    }

    protected void Show()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
        Time.timeScale = 0;
    }

    protected void Hide()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
        Time.timeScale = 1;
    }
}
