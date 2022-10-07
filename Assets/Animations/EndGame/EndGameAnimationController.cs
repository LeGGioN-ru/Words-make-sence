using System;
using UnityEngine;

[Serializable]
public static class EndGameAnimationController
{
    public static class States
    {
        public static readonly int Lose = Animator.StringToHash("Lose");
    }
}
