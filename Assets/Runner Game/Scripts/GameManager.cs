using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonCreator<GameManager>
{
    [ContextMenu("LoadNextLevel")] 
    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }
    
}
