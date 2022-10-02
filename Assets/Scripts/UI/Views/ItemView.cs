using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class ItemView : MonoBehaviour
{
    [SerializeField] protected TMP_Text ApptembsActivate;
    [SerializeField] protected Image Icon;
    [SerializeField] protected TMP_Text Title;

    public virtual void Init(Phrase phrase)
    {
        Title.text = phrase.Title;
        ApptembsActivate.text = phrase.ApptembsToActivate.ToString();
        Icon.sprite = phrase.Icon;
    }
}
