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
