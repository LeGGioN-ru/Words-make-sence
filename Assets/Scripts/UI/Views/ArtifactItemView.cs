using TMPro;
using UnityEngine;

public class ArtifactItemView : ItemView
{
    [SerializeField] private TMP_Text _value;

    public override void Init(Phrase phrase)
    {
        if (phrase is Artifact artifact)
        {
            _value.text = artifact.CurrentValue.ToString();
        }

        base.Init(phrase);
    }
}
