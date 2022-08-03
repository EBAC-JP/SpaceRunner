using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BounceHelper : MonoBehaviour {

    [SerializeField] float scaleDuration;
    [SerializeField] float scaleBounce;
    [SerializeField] Ease ease;

    public void Bounce() {
        transform.DOScale(scaleBounce, scaleDuration).SetEase(ease).SetLoops(2, LoopType.Yoyo);
    }

}
