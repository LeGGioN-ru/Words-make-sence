using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CanvasGroup))]
public abstract class CanvasGroupSwitcher : MonoBehaviour
{
    public event UnityAction Showed;
    public event UnityAction Hided;

    private CanvasGroup _canvasGroup;
    private bool _isVisible;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    protected virtual void OnDisable()
    {
        Hide();
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

    protected virtual void Show()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
        Time.timeScale = 0;
        Showed?.Invoke();
    }

    protected virtual void Hide()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
        Time.timeScale = 1;
        Hided?.Invoke();
    }
}
