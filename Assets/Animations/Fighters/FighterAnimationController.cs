using System;
using UnityEngine;


[Serializable]
public static class FighterAnimationController
{
    public static class States
    {
        public static readonly int Idle = Animator.StringToHash(nameof(Idle));
        public static readonly int Run = Animator.StringToHash(nameof(Run));
        public static readonly int Attack = Animator.StringToHash(nameof(Attack));
        public static readonly int Death = Animator.StringToHash(nameof(Death));
        public static readonly int Magic = Animator.StringToHash(nameof(Magic));
        public static readonly int TakeDamage = Animator.StringToHash(nameof(TakeDamage));
    }

    public static class Params
    {
        public static readonly int Idle = Animator.StringToHash(nameof(Idle));
        public static readonly int IsRun = Animator.StringToHash(nameof(IsRun));
        public static readonly int Attack = Animator.StringToHash(nameof(Attack));
    }
}
