using UnityEngine;
using UnityEngine.UI;

public class ArtifactView : MonoBehaviour
{
    [SerializeField] private Image _image;

    public Artifact Artifact => _artifact;

    private Artifact _artifact;

    public void Init(Artifact artifact)
    {
        _artifact = artifact;
        _image.sprite = artifact.Icon;
        _artifact.Used += OnUsed;
    }

    private void OnDisable()
    {
        _artifact.Used -= OnUsed;
    }

    private void OnUsed()
    {
        Destroy(gameObject);
    }
}
