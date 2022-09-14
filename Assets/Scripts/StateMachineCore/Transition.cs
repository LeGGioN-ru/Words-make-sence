using UnityEngine;

[RequireComponent(typeof(Fighter))]
public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    public bool NeedTransit { get; protected set; }

    public State TargetState => _targetState;
    public Fighter CurrentFighter => _currentFighter;

    private Fighter _currentFighter;

    private void OnEnable()
    {
        _currentFighter = GetComponent<Fighter>();
        NeedTransit = false;
    }
}
