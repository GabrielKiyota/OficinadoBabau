using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss2 : MonoBehaviour
{


    public float speed;
    public float jumpForce;

    private Rigidbody2D rig;
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float movement = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(movement * speed, rig.velocity.y);
    }

    void Jump()
    {
        
    }
}
