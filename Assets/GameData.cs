using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    // Start is called before the first frame update
    public int score = 0;
    public int numberOfLevelUnlocked;

    public string[] currentPlayerNames;
    public List<int> player1Scores= new List<int>();
    public List<int> player2Scores = new List<int>();

}
