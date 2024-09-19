using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour , IObstacle
{
    #region Unity Fields
    [SerializeField] private float damage;
    #endregion
    #region Events
    public static Action<float> onHit;
    #endregion

    #region Fields
    public float Damage { get => damage; set => damage = value; }
    #endregion

    public void Hit()
    {
        onHit?.Invoke(Damage);
    }
}
