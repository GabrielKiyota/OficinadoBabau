 using System;
 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class Boss1 : MonoBehaviour
 {
     public float speed;
     public float walktime;
 
     private float timer;
     private bool walkRight = true;
 
     public int health;
     public int damage = 1;
     
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
 
         if (timer >= walktime)
         {
             walkRight = !walkRight;
             timer = 0f;
         }
 
         if (walkRight)
         {
             transform.eulerAngles = new Vector2(0, 0);
             rig.velocity = Vector2.left * speed;
         }
         else
         {
             transform.eulerAngles = new Vector2(0, 0);
             rig.velocity = Vector2.right * speed;
         }
     }
     
 
     private void OnCollisionEnter2D(Collision2D collision)
     {
         if (collision.gameObject.tag == "Player")
         {
            collision.gameObject.GetComponent<Boss1>(); 
         }
     }
 }

