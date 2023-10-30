using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public int damage;

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<Boss>().Damage(damage);
            Destroy(gameObject);
            
        }
    }

}
