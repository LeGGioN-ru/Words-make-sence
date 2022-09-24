using System;
using UnityEngine;


[Serializable]
public static class FighterAnimationController
{
    public static class States
    {
        public static readonly int Idle = Animator.StringToHash("Idle");
        public static readonly int Run = Animator.StringToHash("Run");
        public static readonly int Attack = Animator.StringToHash("Attack");
        public static readonly int Die = Animator.StringToHash("Die");
        public static readonly int Magic = Animator.StringToHash("Magic");
        public static readonly int TakeDamage = Animator.StringToHash("TakeDamage");
    }

    public static class Params
    {
        public static readonly int Idle = Animator.StringToHash("Idle");
        public static readonly int IsRun = Animator.StringToHash("IsRun");
        public static readonly int Attack = Animator.StringToHash("Attack");
    }
}
