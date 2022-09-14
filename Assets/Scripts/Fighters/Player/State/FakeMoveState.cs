using UnityEngine;

public class FakeMoveState : State
{
    private void OnEnable()
    {
        Animator.SetBool(FighterAnimationController.Params.IsRun, true);
    }
}
