using System.Collections.Generic;
using UnityEngine;

public class ArtifactHolder : MonoBehaviour
{
    [SerializeField] private WeaponHolder _weaponHolder;
    [SerializeField] private ArmorHolder _armorHolder;
    [SerializeField] private MagicHolder _magicHolder;
    [SerializeField] private Transform _container;
    [SerializeField] private ArtifactView _template;
    [SerializeField] private int _maxCount;
    [SerializeField] private Queue<Artifact> _artifacts = new Queue<Artifact>();
    [SerializeField] private PhraseActivator _phraseActivator;

    private Queue<ArtifactView> _views = new Queue<ArtifactView>();

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
            AddArtifact(artifact);

            if (_artifacts.Count > _maxCount)
                RemoveArtifact();
        }
    }

    private void AddArtifact(Artifact artifact)
    {
        _artifacts.Enqueue(artifact);
        artifact.Init();

        var artifactView = Instantiate(_template, _container);
        artifactView.Init(artifact);

        _views.Enqueue(artifactView);
    }

    private void RemoveArtifact()
    {
        _artifacts.Dequeue();
        var artifactView = _views.Dequeue();
        Destroy(artifactView);
    }
}
