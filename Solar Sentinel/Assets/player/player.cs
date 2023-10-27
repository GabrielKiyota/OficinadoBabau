using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidade = 5.0f;
    public float velocidadeDoProjetil = 5.0f;
    public GameObject projetilPrefabA;
    public Transform pontoDeDisparoA; 
    public GameObject projetilPrefabB;
    public Transform pontoDeDisparoB; 
    private float tempoA;
    private float tempoB;
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {

        tempoA = tempoA + Time.deltaTime;
        tempoB = tempoB + Time.deltaTime;

        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");

        Vector3 movimento = new Vector3(movimentoHorizontal, movimentoVertical, 0.0f);

        movimento.Normalize();

        transform.Translate(movimento * velocidade * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.J) && tempoA >= 1)
        {
            DispararA();
            tempoA = 0f;
        }
        if (Input.GetKeyDown(KeyCode.K) && tempoB >= 1)
        {
            DispararB();
            tempoB = 0f;

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            // Define o parâmetro "A_Pressed" como verdadeiro
            anim.SetBool("FoiA", true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            // Define o parâmetro "A_Pressed" como falso
            anim.SetBool("FoiA", false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            // Define o parâmetro "D_Pressed" como verdadeiro
            anim.SetBool("FoiD", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            // Define o parâmetro "D_Pressed" como falso
            anim.SetBool("FoiD", false);
        }
    }
void DispararA()
{
    if (projetilPrefabA != null && pontoDeDisparoA != null)
    {
        GameObject projetil = Instantiate(projetilPrefabA, pontoDeDisparoA.position, pontoDeDisparoA.rotation);

        Rigidbody2D rb = projetil.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
                rb.velocity = transform.up * velocidadeDoProjetil;
        }
    }
}
void DispararB()
{
    if (projetilPrefabB != null && pontoDeDisparoB != null)
    {
        GameObject projetil = Instantiate(projetilPrefabB, pontoDeDisparoB.position, pontoDeDisparoB.rotation);

        Rigidbody2D rb = projetil.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = transform.up * velocidadeDoProjetil;
        }
    }
    
}
}