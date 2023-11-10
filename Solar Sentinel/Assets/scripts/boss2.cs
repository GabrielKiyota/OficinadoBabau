using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class boss2 : MonoBehaviour
{
    public int health;
    public float speed = 5f;
    public float walkTime = 2;
    public bool walkRight = false;
    
    private float timer;
    private Rigidbody2D rig;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= walkTime)
        {
            walkRight = !walkRight;
            timer = 0f;
        }

        if(walkRight)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            rig.velocity = Vector2.right * speed;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            rig.velocity = Vector2.left * speed;
        } 
        
       

        
        
         
    }

    void Damage(int dmg)
    {
        health -= dmg;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Inimigo"));
        {
            Damage(1);
        }
    }

        
    
} 