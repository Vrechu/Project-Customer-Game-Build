using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameManager : MonoBehaviour
{
    public static MainGameManager GetMainManager()
    {
        return currentManager;
    }
    static MainGameManager currentManager = null;

    public string winSceneName;

    void Awake()
    {
        if (currentManager == null)
        {
            currentManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        ManageScore.OnAllTrashCollected += WinGame;
        ManageHealth.OnPlayerDeath += LoseGame;
    }

    void OnDestroy()
    {
        ManageScore.OnAllTrashCollected -= WinGame;
        ManageHealth.OnPlayerDeath -= LoseGame;
    }

    void Start()
    {

    }

    void Update()
    {
    }

    /// <summary>
    /// Freezes time in game.
    /// </summary>
    public static void PauseGame()
    {
        Time.timeScale = 0;
    }

    /// <summary>
    /// Unfreezes time in game.
    /// </summary>
    public static void UnpauseGame()
    {
        Time.timeScale = 1;
    }

    void WinGame()
    {
        ManageScenes.ChangeScene("WinScene");
    }

    void LoseGame()
    {
        ManageScenes.ChangeScene("LoseScene");
    }
}
