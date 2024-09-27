using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : BaseCollectible
{
    public override void Collected()
    {
        base.Collected();
        float shrinkDuration = .2f;
        transform.DOScale(Vector3.zero, shrinkDuration).OnComplete(() =>
        {
            CreateGameObjects.Instance.CreateGameObject(CommonVariables.SpawnedObjects.CollectedParticle.ToString(), transform.position, null);
            ResetObject();
        });
    }
}
