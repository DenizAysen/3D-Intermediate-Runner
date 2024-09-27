using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : SingletonCreator<GameManager>
{
    #region Unity Fields
    [SerializeField] PanelBase[] panelBase;
    [SerializeField] Image healthFill;
    [SerializeField] TextMeshProUGUI scoreText;
    #endregion
    #region Actions
    public static Action onStartGame;
    #endregion
    #region Fields
    private PlayerHealth _playerHealth;
    private int _currentScore = 0;
    #endregion
    #region Unity Methods
    private void OnEnable()
    {
        PlayerHealth.onPlayerDied += OnPlayerDied;
        ObstacleBase.onHit += OnHit;
        BaseCollectible.onCollected += OnCollected;
        PlayerCollector.onFinished += OnFinished;
        healthFill.fillAmount = 1f;
    }
    private void OnDisable()
    {
        PlayerHealth.onPlayerDied -= OnPlayerDied;
        ObstacleBase.onHit -= OnHit;
        BaseCollectible.onCollected -= OnCollected;
        PlayerCollector.onFinished -= OnFinished;
    }
    private void Start()
    {
        SetPanel(CommonVariables.PanelTypes.Start);
        _playerHealth = FindObjectOfType<PlayerHealth>();
    }
    #endregion
    #region Private Methods
    private void SetPanel(CommonVariables.PanelTypes panelType)
    {
        DisableAllPanels();
        panelBase[(int)panelType].gameObject.SetActive(true);
    }

    private void DisableAllPanels()
    {
        foreach (var panel in panelBase)
        {
            panel.gameObject.SetActive(false);
        }
    }
    private void OnPlayerDied()
    {
        SetPanel(CommonVariables.PanelTypes.Failed);
        Debug.Log("Burasi calisti");
    }
    private void OnHit(float damage)
    {
        float fillAmount = _playerHealth.GetCurrentHealth() / _playerHealth.GetMaxHealth();
        healthFill.DOFillAmount(fillAmount, .5f);
    }
    private void OnCollected()
    {
        _currentScore += 10;
        scoreText.text = _currentScore.ToString();
    }
    private void OnFinished()
    {
        SetPanel(CommonVariables.PanelTypes.Success);
    }
    #endregion
    #region Public Methods
    public void StartGame()
    {
        onStartGame?.Invoke();
        SetPanel(CommonVariables.PanelTypes.InGame);
    }
    #endregion
    [ContextMenu("LoadNextLevel")] 
    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }
    
}
