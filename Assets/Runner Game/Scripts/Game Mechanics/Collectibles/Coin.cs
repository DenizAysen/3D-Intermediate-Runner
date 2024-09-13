using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectible
{
    #region Interface Methods
    public void Collected()
    {
        GameObject gmo = CreateGameObjects.Instance.CreateGameObject(CommonVariables.SpawnedObjects.CollectedParticle.ToString(), transform.position, null);
        gameObject.SetActive(false);
    }
    #endregion
}
