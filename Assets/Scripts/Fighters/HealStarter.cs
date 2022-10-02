using UnityEngine;

public class HealStarter : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    public void ExecuteStart()
    {
        if (_particleSystem != null)
            _particleSystem.Play();
    }
}
