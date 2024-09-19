using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonCreator<GameManager>
{
    #region Unity Fields
    [SerializeField] PanelBase[] panelBase;
    #endregion
    #region Actions
    public static Action onStartGame;
    #endregion
    #region Unity Methods
    private void OnEnable()
    {
        PlayerHealth.onPlayerDied += OnPlayerDied;
    }
    private void OnDisable()
    {
        PlayerHealth.onPlayerDied -= OnPlayerDied;
    }
    private void Start()
    {
        SetPanel(CommonVariables.PanelTypes.Start);
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
    #endregion
    #region Public Methods
    public void StartGame()
    {
        onStartGame?.Invoke();
        DisableAllPanels();
    }
    #endregion
    [ContextMenu("LoadNextLevel")] 
    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }
    
}
