using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void Continue()
    {
        SceneManager.LoadSceneAsync("DataStolen");
    }

    public void Input()
    {
        SceneManager.LoadSceneAsync("DataGatheringScene");
    }

    public void levelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
