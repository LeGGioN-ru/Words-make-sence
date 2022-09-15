using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DieState : State
{
    private void Start()
    {
        var animator = GetComponent<Animator>();
        animator.Play(FighterAnimationController.States.Die);
    }
}
