using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float velocidade = 5.0f; // Velocidade de movimento do personagem
    public float velocidadeDoProjetil = 5.0f;
    public GameObject projetilPrefabA; // Prefab do objeto a ser disparado
    public Transform pontoDeDisparoA; // Ponto de origem do disparo
    public GameObject projetilPrefabB; // Prefab do objeto a ser disparado
    public Transform pontoDeDisparoB; // Ponto de origem do disparo
    void Update()
    {
        // Obtém os inputs de movimentação
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");

        // Calcula o vetor de movimentação
        Vector3 movimento = new Vector3(movimentoHorizontal, movimentoVertical, 0.0f);

        // Normaliza o vetor de movimentação para evitar movimentos diagonais mais rápidos
        movimento.Normalize();

        // Move o personagem
        transform.Translate(movimento * velocidade * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.J))
        {
            DispararA();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            DispararB();
        }
    }
void DispararA()
{
    // Certifique-se de que o prefab do objeto a ser disparado está configurado no Inspector
    if (projetilPrefabA != null && pontoDeDisparoA != null)
    {
        // Crie uma cópia do objeto a ser disparado no ponto de disparo
        GameObject projetil = Instantiate(projetilPrefabA, pontoDeDisparoA.position, pontoDeDisparoA.rotation);

        // Adicione velocidade ao projetil (ajuste conforme necessário)
        Rigidbody2D rb = projetil.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = transform.up * velocidadeDoProjetil; // Define a direção e velocidade do projetil
        }
    }
}
void DispararB()
{
    // Certifique-se de que o prefab do objeto a ser disparado está configurado no Inspector
    if (projetilPrefabB != null && pontoDeDisparoB != null)
    {
        // Crie uma cópia do objeto a ser disparado no ponto de disparo
        GameObject projetil = Instantiate(projetilPrefabB, pontoDeDisparoB.position, pontoDeDisparoB.rotation);

        // Adicione velocidade ao projetil (ajuste conforme necessário)
        Rigidbody2D rb = projetil.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = transform.up * velocidadeDoProjetil; // Define a direção e velocidade do projetil
        }
    }
}
}