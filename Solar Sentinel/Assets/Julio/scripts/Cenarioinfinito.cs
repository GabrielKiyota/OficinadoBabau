using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cenarioinfinito : MonoBehaviour
{

    public float velocidadeDocenario;

    // Update is called once per frame
    void Update()
    {
        movimentarcenario();
    }
    private void movimentarcenario()
    {
        Vector2 deslocamento = new Vector2(Time.time * velocidadeDocenario, 0);
        GetComponent<Renderer>().material.mainTextureOffset = deslocamento;
    }
}


