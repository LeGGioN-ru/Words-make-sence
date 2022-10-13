using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class ArtifactHolder : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private ArtifactView _template;
    [SerializeField] private int _maxCount;
    [SerializeField] private PhraseActivator _phraseActivator;

    private Player _player;

    private List<ArtifactView> _views = new List<ArtifactView>();

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _phraseActivator.Activated += OnActivated;
    }

    private void OnDisable()
    {
        _phraseActivator.Activated -= OnActivated;
    }

    private void OnActivated(Phrase phrase)
    {
        if (phrase is Artifact artifact)
        {
            if (_views.Count > _maxCount)
                RemoveArtifact();

            AddArtifact(artifact);
        }
    }

    private void RemoveArtifact()
    {
        int firstArtifactIndex = 0;
        _views[firstArtifactIndex].Artifact.Use();
    }

    private void AddArtifact(Artifact artifact)
    {
        artifact.Init(_player);
        var artifactView = Instantiate(_template, _container);
        artifactView.Init(artifact);
        _views.Add(artifactView);
    }
}
