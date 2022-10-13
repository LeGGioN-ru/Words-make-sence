using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicChanger : MonoBehaviour
{
    [SerializeField] private AudioClip _startMusic;
    [SerializeField] private Spawner _spawner;

    private AudioSource _music;
    private Boss _boss;

    private void Awake()
    {
        _music = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _spawner.EnemySpawned += OnEnemySpawned;
    }

    private void OnDisable()
    {
        _spawner.EnemySpawned -= OnEnemySpawned;
    }

    private void OnEnemySpawned(Enemy enemy)
    {
        if (enemy is Boss boss)
        {
            boss.Died += OnDied;
            _boss = boss;
            _music.clip = boss.Music;
            _music.Play();
        }
    }

    private void OnDied()
    {
        _music.clip = _startMusic;
        _music.Play();

        _boss.Died -= OnDied;
    }
}
