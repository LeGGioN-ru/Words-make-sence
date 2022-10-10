using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Fighter))]
public class AttackState : State
{
    public event UnityAction AttackStarted;

    private void OnEnable()
    {
        Animator.SetBool(FighterAnimationController.Params.IsRun, false);
    }

    protected virtual void Update()
    {
        AttackStarted?.Invoke();
    }
}
