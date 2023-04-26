using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Data;

[System.Serializable]
public class SortingExample : MonoBehaviour
{
    public GameMaster gameMaster;
    List<int> SoloScores = new List<int>();
    int i = 1;

    [SerializeField]
    TextMeshProUGUI leaderBoardTxt;

    private void Start()
    {
        foreach (int score in gameMaster.saveData.player1Scores)
        {
            SoloScores.Add(score);
        }
    }

    private void Update()
    {

    }

    public void sortP1Score()
    {
        SoloScores.Sort(SortFunc);

        foreach (int k in SoloScores)
        {
            leaderBoardTxt.text += i.ToString() + ". " + k + "<br>";
            i++;
        }
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

    public void sortP1Clear()
    {
        leaderBoardTxt.text = string.Empty;
        i = 1;
    }

    public void exitGame()
    { 
        Application.Quit();
    }


}

