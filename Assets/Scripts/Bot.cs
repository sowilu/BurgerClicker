using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bot : MonoBehaviour
{
    public float distance = 0.3f;
    public float duration = 0.5f;
    public Ease ease = Ease.OutBounce;

    private Vector3 startPosition;
    
    void Start()
    {
        Invoke(nameof(Animate), Random.Range(0.8f, 2f));
        startPosition = transform.localPosition;
    }

    void Animate()
    {
        transform.DOLocalMove(-startPosition.normalized * distance, duration).SetEase(ease).SetLoops(-1, LoopType.Yoyo);
    }

    private void Update()
    {
        transform.LookAt(transform.parent);
    }
}
