using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public GameData saveData;
    static public GameMaster instance; 

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        saveData = SaveSystemScript.instance.LoadGame();
    }

    private void Start()
    {
        
        saveData = SaveSystemScript.instance.LoadGame();
    }

    private void Update()
    {

    }

    public void SaveP1Score()
    {
        saveData.player1Scores.Add(StageManager.instance.player1Score);
        saveData.player1Scores.Sort(SortFunc);
        SaveSystemScript.instance.SaveGame(saveData);

    }

    public void SaveP2Score()
    {
        saveData.player2Scores.Add(StageManager.instance.player2Score);
        saveData.player2Scores.Sort(SortFunc);
        SaveSystemScript.instance.SaveGame(saveData);
    }

    int SortFunc(int a, int b)
    {
        if (a < b)
        {
            return +1;
        }
        if (a > b)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }

    public void resetScore()
    {
        saveData.player1Scores.Clear();
        SaveSystemScript.instance.SaveGame(saveData);
    }


}
