using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Keeps players basic properties
/// </summary>
[RequireComponent(typeof(Rigidbody),typeof(Animator))]
public class Player : MonoBehaviour
{
    #region Properties
    protected bool isControlEnabled;
    protected bool isPlayedDead;
    protected Rigidbody rb;
    protected Animator animator;
    #endregion

    #region Unity Methods
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    } 
    #endregion
}
