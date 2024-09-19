using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Coin : MonoBehaviour, ICollectible
{
    #region Fields
    Vector3 _initialScale;
    Collider _collider;
    #endregion
    #region Unity Methods
    private void Start()
    {
        _initialScale = transform.localScale;
        _collider = GetComponent<Collider>();
    } 
    #endregion
    #region Interface Methods
    public void Collected()
    {
        _collider.enabled = false;

        float shrinkDuration = .2f;
        transform.DOScale(Vector3.zero, shrinkDuration).OnComplete(() =>
        {
            CreateGameObjects.Instance.CreateGameObject(CommonVariables.SpawnedObjects.CollectedParticle.ToString(), transform.position, null);
            ResetObject();
        });
    }
    #endregion
    #region Private Methods
    private void ResetObject()
    {
        gameObject.SetActive(false);
        transform.localScale = _initialScale;
        _collider.enabled=true;
    } 
    #endregion
}
