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


}
