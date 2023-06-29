using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Data;

[System.Serializable]
public class SortingExample : MonoBehaviour
{
    List<int> SoloScores = new List<int>();
    List<int> ScoreOnDeath = new List<int>();
    int i = 1;

    [SerializeField]
    TextMeshProUGUI leaderBoardTxt;
    [SerializeField]
    TextMeshProUGUI finalScore;

    private void Start()
    {
        foreach (int score in GameMaster.instance.saveData.player1Scores)
        {
            SoloScores.Add(score);
        }
    }

    private void Update()
    {

    }


    public void runShowScore()
    {
        Debug.Log("runshowscoreStart");
        Invoke("showScoreOnDeath", 2f);
    }
    public void showScoreOnDeath()
    {
        finalScore.text = "";
        Debug.Log("ShowScore");
        ScoreOnDeath.Clear();
        foreach (int score in GameMaster.instance.saveData.player1Scores)
        {
            ScoreOnDeath.Add(score);
            ScoreOnDeath.Sort(SortFunc);
        }
        foreach (int k in ScoreOnDeath)
        {

            finalScore.text += i.ToString() + ". " + k + "<br>";
            i++;
        }
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

