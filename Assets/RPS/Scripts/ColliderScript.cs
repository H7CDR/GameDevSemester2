using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ColliderScript : hitDetector
{

    [SerializeField]
    enum TypeOfCollision { Rock, Paper, Scissors };
    [SerializeField]
    TypeOfCollision currentType;
    [SerializeField]
    float dist;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dist = distanceToHitter;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(currentType.ToString()) && distanceToHitter > 0.5f&& distanceToHitter < 2)
        {
            Debug.Log(currentType.ToString());
            Destroy(other.gameObject);
            Debug.Log("OKAY!");
        }
        else if (other.CompareTag(currentType.ToString()) && distanceToHitter <0.5f)
        {
            Debug.Log(currentType.ToString());
            Destroy(other.gameObject);
            Debug.Log("PERFECT");
        }
        else if (!other.CompareTag(currentType.ToString()))
        {
            Debug.Log("WrongType");
        }
    }
}
