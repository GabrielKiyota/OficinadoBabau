using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDoBoss1 : MonoBehaviour
{
    private Rigidbody2D rig;

    public float speed;

    public float damage;

    public PlayerPrefs Boss1;
    
    public float valocidadeDoLaser;
    // Start is called before the first frame update
    void Start()
    {
              Boss1 = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPrefs>();
              rig = GetComponent<Rigidbody2D>();
              Destroy(gameObject, 1f);
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
    
    private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.GetComponent<PlayerPrefs>().AtirarLaser(damage);
                Destroy(gameObject);
            }
        }
    }

