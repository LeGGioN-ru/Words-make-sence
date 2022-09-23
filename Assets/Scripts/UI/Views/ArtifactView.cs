using UnityEngine;
using UnityEngine.UI;

public class ArtifactView : MonoBehaviour
{
    [SerializeField] private Image _image;

    public void Init(Artifact artifact)
    {
        _image.sprite = artifact.Icon;
    }
}
