using System;
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
    protected virtual void Awake()
    {
        isControlEnabled = false;
        isPlayedDead = false;
    }
    private void OnEnable()
    {
        GameManager.onStartGame += OnStartGame;
        Barrier.onHit += OnHit;
    }

    private void OnHit()
    {
        //animator.SetTrigger("Hit");
        animator.SetTrigger("Die");
    }

    private void OnDisable()
    {
        GameManager.onStartGame -= OnStartGame;
        Barrier.onHit -= OnHit;
    }
    private void OnStartGame()
    {
        isControlEnabled = true;
        isPlayedDead = false;
    }

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    } 
    #endregion
}
