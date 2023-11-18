using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchMachine : Obstacle
{

    protected override void Play()
    {
        tr.DOLocalMoveX(-2.6f, TweenDuration).SetLoops(-1, LoopType.Yoyo).SetEase(EaseType);
    }

    protected override void Stop()
    {
        tr.DOKill();
    }


}
