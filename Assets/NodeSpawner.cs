using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NodeSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject _sphere;
    [SerializeField]
    GameObject _paper;
    [SerializeField]
    GameObject _scissors;
    [SerializeField]
    GameObject[] _spawnables;
    [SerializeField]
    float _spawnInterval;
    float _timer;
    [SerializeField]
    float _bpm;
    [SerializeField]
    GameObject _spawnPoint, _p2SpawnPoint;

    [SerializeField]
    UnityEvent obJectSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        _spawnInterval = 60f / _bpm;
    }
    // Update is called once per frame
    void Update()
    {
        if(_timer >= _spawnInterval)
        {
            spawnRandom();
            _timer = 0;
        }
        else
        {
           _timer += Time.deltaTime;
        }

    }

    public void SpawnRock()
    {
        Instantiate(_sphere, _spawnPoint.transform.position, Quaternion.identity);
    }

    public void SpawnPaper()
    {
        Instantiate(_paper, _spawnPoint.transform.position, Quaternion.identity);
    }    

    public void SpawnScissors()
    {
        Instantiate(_scissors, _spawnPoint.transform.position, Quaternion.identity);
    }

    public void spawnRandom()
    {
        Instantiate(_spawnables[Random.Range(0,3)],_spawnPoint.transform.position, Quaternion.identity);    
        
    }

    public void p2SpawnRandom()
    {
        Instantiate(_spawnables[Random.Range(0, 3)], _p2SpawnPoint.transform.position, Quaternion.identity);
    }
}
