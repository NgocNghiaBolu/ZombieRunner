using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneGame : MonoBehaviour
{
    public void AgainScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;// quay lai mode ban dau
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Out");
    }
    
}
