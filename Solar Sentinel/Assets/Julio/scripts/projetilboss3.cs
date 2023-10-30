using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projetilboss3 : MonoBehaviour
{
    public player vida;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("acertou");
            
        }

        // Destruir o objeto com um atraso de 2 segundos
        
    }
}
