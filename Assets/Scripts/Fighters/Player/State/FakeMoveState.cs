using UnityEngine;
using UnityEngine.Events;

public class FakeMoveState : State
{
    public event UnityAction MoveStart;

    private void OnEnable()
    {
        Animator.SetBool(FighterAnimationController.Params.IsRun, true);
        MoveStart?.Invoke();
    }
}
