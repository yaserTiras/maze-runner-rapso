using DG.Tweening;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    [SerializeField] private Ease easeType;
    [SerializeField] private float tweenDuration;
    [SerializeField] protected Transform tr;
    protected float TweenDuration => tweenDuration;
    protected Ease EaseType => easeType;
    protected abstract void Play();
    protected abstract void Stop();


    protected virtual void OnEnable()
    {
        Play();
    }

    protected virtual void OnDisable()
    {
        Stop();
    }
}
