using UnityEngine;

public class MoveState : State
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Vector2 _direction;

    private void OnEnable()
    {
        Animator.SetBool(FighterAnimationController.Params.IsRun, true);
    }

    private void Update()
    {
        transform.Translate(_moveSpeed * Time.deltaTime * _direction);
    }
}
