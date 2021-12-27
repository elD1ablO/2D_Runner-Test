using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] GameObject gameOverUI;

    void Awake()
    {
        /*if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }*/
        instance = this;
        //DontDestroyOnLoad(gameObject);        
    }

    public void PauseMenuUI()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GameOverMenuUI()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }
    
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); 
#endif        
    }
}
