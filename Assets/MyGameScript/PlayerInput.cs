using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public string rock, paper, scissors;
    public List<string> p1Input;
    public List<string> p2Input;

    void Start()
    {
        Debug.Log(p1Input.Count + "+" + p2Input.Count);
    }

    void Update()
    {

    }
    void Rock()
    {
        p1Input.Add("rock");
    }
    void Paper()
    {

    }
    void Scissors()
    {

    }
    void compareInput()
    {

    }
}
