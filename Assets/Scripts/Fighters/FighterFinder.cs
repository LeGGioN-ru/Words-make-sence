using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FighterFinder : MonoBehaviour
{
    [SerializeField] private Vector2 _direction;
    [SerializeField] private float _distance;
    [SerializeField] ContactFilter2D _filter;

    private List<RaycastHit2D> _hits = new List<RaycastHit2D>();

    public Fighter Execute()
    {
        Physics2D.Raycast(transform.position, _direction, _filter, _hits, _distance);

        foreach (var hit in _hits)
        {
            if (hit.collider.TryGetComponent(out Fighter fighter))
            {
                return fighter;
            }
        }

        return null;
    }
}
