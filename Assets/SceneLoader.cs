using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    public void sceneLoader (int sceneIndex)
    {
        SceneManager.LoadScene (sceneIndex);
        Time.timeScale = 1.0f;
        
    }

    public void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }

    public void sceneLoaderName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1.0f;
    }

    public void closeGame()
    {
        SaveSystemScript.instance.SaveGame(GameMaster.instance.saveData);
        Application.Quit();
    }
    
    
}
