using UnityEngine;

[RequireComponent(typeof(Fighter))]
public class StateMachine : MonoBehaviour
{
    [SerializeField] private State _startState;

    private State _currentState;

    public State CurrentState => _currentState;

    private void Start()
    {
        SetStartState(_startState);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        var nextState = _currentState.GetNextState();

        if (nextState != null)
            Transit(nextState);
    }

    private void SetStartState(State startState)
    {
        _currentState = startState;

        if (_currentState != null)
            _currentState.Enter();
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState != null)
            _currentState.Enter();
    }
}
