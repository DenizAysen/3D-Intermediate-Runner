using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ObstacleBase : MonoBehaviour,IObstacle
{
    #region Properties
    public float Damage { get; set; }
    protected Collider objCollider;
    #endregion  
    #region Events
    public static Action<float> onHit;
    #endregion
    public virtual void Hit()
    {
        onHit?.Invoke(Damage);
        objCollider.enabled = false;
    }
    protected virtual void Start()
    {
        objCollider = GetComponent<Collider>();
    }

}
