using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    public void sceneLoader (int sceneIndex)
    {
        SceneManager.LoadScene (sceneIndex);
        
    }

    public void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void sceneLoaderName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void closeGame()
    {
        SaveSystemScript.instance.SaveGame(GameMaster.instance.saveData);
        Application.Quit();
    }

    
}
