using DG.Tweening;
using UnityEngine;

public class Swiper : Obstacle
{
    protected override void Play()
    {
        tr.DOLocalRotate(Vector3.forward * 360f, TweenDuration, RotateMode.LocalAxisAdd).SetLoops(-1, LoopType.Incremental).SetEase(EaseType);
    }

    protected override void Stop()
    {
        tr.DOKill();
    }
}
