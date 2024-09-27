using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BaseCollectible : MonoBehaviour , ICollectible
{
    #region Fields
    protected Vector3 _initialScale;
    protected Collider _collider;
    #endregion
    #region Actions
    public static Action onCollected;
    #endregion
    #region Unity Methods
    protected void Start()
    {
        _initialScale = transform.localScale;
        _collider = GetComponent<Collider>();
    }
    #endregion
    #region Virtual Methods
    public virtual void Collected()
    {
        onCollected?.Invoke();
        _collider.enabled = false;
    }
    protected virtual void ResetObject()
    {
        gameObject.SetActive(false);
        transform.localScale = _initialScale;
        _collider.enabled = true;
    } 
    #endregion
}
