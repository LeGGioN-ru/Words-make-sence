using UnityEngine;

public class MoveState : State
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private int _direction;

    private void OnEnable()
    {
        Animator.SetBool(FighterAnimationController.Params.IsRun, true);
    }

    private void Update()
    {
        transform.Translate(new Vector2(_moveSpeed * Time.deltaTime * _direction, 0));
    }
}
