using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDoBoss1 : MonoBehaviour
{
    public float valocidadeDoLaser;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarLaser();
    }

    private void MovimentarLaser()
    {
        transform.Translate(Vector3.up * valocidadeDoLaser * Time.deltaTime);
    }
}

