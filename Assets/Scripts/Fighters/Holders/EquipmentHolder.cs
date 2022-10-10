using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Fighter))]
public abstract class EquipmentHolder : MonoBehaviour
{
    [SerializeField] private PhraseActivator _phraseActivator;

    public event UnityAction<Equipment> Changed;

    protected float PassedTime;
    protected Animator Animator;
    protected Fighter Fighter;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
        Fighter = GetComponent<Fighter>();
    }

    abstract protected void Start();

    protected virtual void OnEnable()
    {
        if (_phraseActivator != null)
            _phraseActivator.Activated += OnActivated;
    }

    protected virtual void OnDisable()
    {
        if (_phraseActivator != null)
            _phraseActivator.Activated -= OnActivated;
    }

    protected void Change(Equipment equipment)
    {
        Changed?.Invoke(equipment);
    }

    protected abstract void OnActivated(Phrase phrase);
}
