using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : ObstacleBase
{
    #region Unity Fields
    [SerializeField] private float damage;
    #endregion
    #region Unity Methods
    protected override void Start()
    {
        base.Start();
        Damage = damage;
    }
    #endregion
    public override void Hit()
    {
        base.Hit();
        float rotateDuration = .4f;
        transform.DORotate(new Vector3(90, 0, 0), rotateDuration, RotateMode.Fast).OnComplete(() =>
        {
            float moveDuration = .4f;
            transform.DOMoveY(-3f, moveDuration).OnComplete(() =>
            {
                objCollider.enabled = true;
            });
        });
    }
}
