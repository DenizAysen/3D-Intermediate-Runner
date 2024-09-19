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
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        GameManager.onStartGame += OnStartGame;
        //Barrier.onHit += OnHit;
    }
    private void OnDisable()
    {
        GameManager.onStartGame -= OnStartGame;
        //Barrier.onHit -= OnHit;
    }
    #endregion
    #region Privates
    //private void OnHit(float damage)
    //{
    //    animator.SetTrigger(CommonVariables.PlayerAnimsTriggers.Hit.ToString());
    //    animator.SetTrigger(CommonVariables.PlayerAnimsTriggers.Die.ToString());
    //}
    private void OnStartGame()
    {
        isControlEnabled = true;
        isPlayedDead = false;
    }
    #endregion
}
