using System;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private Animation currentAnimation;
    public void PlayAnimation(Animation animation)
    {
        if (animation == currentAnimation)
            return;

        currentAnimation = animation;
        switch (animation)
        {
            case Animation.Idle:
                anim.SetInteger("State", 0);
                break;
            case Animation.Run:
                anim.SetInteger("State", 1);
                break;
            case Animation.Dance:
                anim.SetInteger("State", 2);
                break;
            default:
                break;
        }
    }


}

public enum Animation
{
    Idle, Run, Dance
}
