using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed = 30;
    public bool randomise = true;
    public Vector3 direction = Vector3.forward;
    
    void Start()
    {
        if (randomise)
        {
            direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        }
    }

    void Update()
    {
        transform.Rotate(direction, speed * Time.deltaTime);
    }
}
