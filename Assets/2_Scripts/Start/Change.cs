using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Change : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("Main");
    }

    
    public void GameExit()
    {
        Application.Quit();
    }

    private void Start()
    {
        Debug.Log($"myTime " + GameManager.myTime);
        Debug.Log($"minTime " + GameManager.minTime);

        
    }
    public void ReplayGame()
    {
        
        SceneManager.LoadScene("Main");
    }

    public void ReplayMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
}
