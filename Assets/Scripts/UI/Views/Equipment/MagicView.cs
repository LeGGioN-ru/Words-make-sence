using TMPro;
using UnityEngine;

public class MagicView : ItemView
{
    [SerializeField] protected TMP_Text Value;
    [SerializeField] protected TMP_Text ManaCost;
    [SerializeField] protected TMP_Text CastDelay;

    public override void Init(Phrase phrase)
    {
        if (phrase is Magic magic)
        {
            Value.text = magic.CurrentValue.ToString();
            ManaCost.text = magic.ManaCost.ToString();
            CastDelay.text = magic.CastDelay.ToString();
        }

        base.Init(phrase);
    }
}
