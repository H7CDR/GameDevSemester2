using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NodeSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject _sphere;
    [SerializeField]
    float _spawnInterval;
    float _timer;
    [SerializeField]
    GameObject _spawnPoint;

    [SerializeField]
    UnityEvent obJectSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_timer >= _spawnInterval)
        { 
            Instantiate(_sphere, _spawnPoint.transform.position, Quaternion.identity);
            _timer = 0;
        }
        else
        {
           _timer += Time.deltaTime;
        }

    }

}
