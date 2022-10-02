using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Fighter))]
public abstract class EquipmentHolder : MonoBehaviour
{
    [SerializeField] private PhraseActivator _phraseActivator;

    public event UnityAction<Equipment> Changed;
    public event UnityAction<Equipment> Equip;

    protected Equipment Equipment;
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

        Changed += OnChanged;
    }

    protected virtual void OnDisable()
    {
        if (_phraseActivator != null)
            _phraseActivator.Activated -= OnActivated;

        Changed -= OnChanged;
    }

    protected virtual void OnChanged(Equipment equipment)
    {
        Equip?.Invoke(equipment);
    }

    protected void OnActivated(Phrase phrase)
    {
        if (phrase is Equipment equipment)
        {
            Equipment = equipment;
            Changed?.Invoke(equipment);
        }
    }
}
