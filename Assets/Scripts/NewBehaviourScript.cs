using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {
        SceneManager.LoadSceneAsync("LevelSelect");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QUIT!");
    }
    public void Lvl01()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void Lvl02()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void Lvl03()
    {
        SceneManager.LoadSceneAsync(3);
    }
    public void Lvl04()
    {
        SceneManager.LoadSceneAsync(4);
    }
    public void Lvl05()
    {
        SceneManager.LoadSceneAsync(5);
    }
    public void Lvl06()
    {
        SceneManager.LoadSceneAsync(6);
    }
    public void BackToStart()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
