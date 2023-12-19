using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneGame : MonoBehaviour
{
    public void AgainScene1()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;// quay lai mode ban dau
    }

    public void AgainScene2()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;// quay lai mode ban dau
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void AgainGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Out");
    }
    
}
