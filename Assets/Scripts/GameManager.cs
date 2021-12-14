using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject PauseMenu;
    public static bool GameIsPaused = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void PlayButton()
    {
        SceneManager.LoadSceneAsync("DataGatheringScene");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QUIT!");
    }
    public void Lvl01()
    {
        SceneManager.LoadSceneAsync(3);
    }
    public void Lvl02()
    {
        SceneManager.LoadSceneAsync(4);
    }
    public void Lvl03()
    {
        SceneManager.LoadSceneAsync(5);
    }
   
    public void BackToStart()
    {
        SceneManager.LoadScene("StartMenu");
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
}
