using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projetilboss3 : MonoBehaviour
{
    public player vida;
    public int damage12;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("acertou");
            player playerScript = collision.gameObject.GetComponent<player>();
            if (playerScript != null)
            {
                playerScript.damage1(damage12);
            }
        }
        Destroy(gameObject);
    }
}
