using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aura : MonoBehaviour

    
{
    public float vidaaura;
    public Transform boss;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = boss.position;
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("raioLaser"))
        {
            vidaaura = vidaaura - 1;

        }

        
    }

}
