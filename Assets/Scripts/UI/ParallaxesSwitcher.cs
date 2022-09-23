using UnityEngine;

public class ParallaxesSwitcher : MonoBehaviour
{
    [SerializeField] private Parallax[] _parallaxes;
    [SerializeField] private AttackState _attackState;
    [SerializeField] private FakeMoveState _fakeMoveState;

    private void OnEnable()
    {
        _attackState.AttackStarted += Disable;
        _fakeMoveState.MoveStart += Enable;
    }

    private void OnDisable()
    {
        _attackState.AttackStarted -= Disable;
        _fakeMoveState.MoveStart -= Enable;
    }

    private void Enable()
    {
        foreach (var parallax in _parallaxes)
        {
            parallax.enabled = true;
        }
    }

    private void Disable()
    {
        foreach (var parallax in _parallaxes)
        {
            parallax.enabled = false;
        }
    }
}
