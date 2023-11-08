using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D baleta)
    {
        if (baleta.CompareTag("Inimigo"))
        {
            Destroy(gameObject);
        }
    }

}
