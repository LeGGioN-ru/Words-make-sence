using UnityEngine;

public class Boss : Enemy
{
    [SerializeField] private AudioClip _music;

    public AudioClip Music=>_music;
}
