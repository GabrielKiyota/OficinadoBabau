using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public string danoInimigo;
    public int vida = 3;
    public float velocidade = 5.0f;
    public float velocidadeDoProjetil = 5.0f;
    public GameObject projetilPrefabA;
    public Transform pontoDeDisparoA; 
    public GameObject projetilPrefabB;
    public Transform pontoDeDisparoB; 
    private float tempoA;
    private float tempoB;
    public Animator anim;
    private float tempoMortal;
    private bool vivencia;
    public SpriteRenderer sprite;
    public bool morreu;
    public bool ultimoMoveA;

    public bool ultimoMoveD;

    private float tempoDash = 0.5f;
    private bool noDash = false;

    public bool matouBoss1;
    public bool matouBoss2;



    public Text vidaText;
    public Text BalaA;
    public Text BalaB;

    public AudioSource Tiro;


    public GameObject telaDeMorte;


    private void Start()
    {
        anim = GetComponent<Animator>();
        Tiro = GetComponent<AudioSource>();
        velocidade = 5f;
    }
    void Update()
    {
        tempoMortal = tempoMortal + Time.deltaTime;
        tempoA = tempoA + Time.deltaTime;
        tempoB = tempoB + Time.deltaTime;

        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");

        Vector3 movimento = new Vector3(movimentoHorizontal, movimentoVertical, 0.0f);

        movimento.Normalize();

        transform.Translate(movimento * velocidade * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.J) && tempoA >= 1 && vida > 0)
        {
            DispararA();
            tempoA = 0f;
        }

        if (Input.GetKeyDown(KeyCode.K) && tempoB >= 1 && vida > 0)
        {
            DispararB();
            tempoB = 0f;
        }

        if (Input.GetKeyDown(KeyCode.A) && vida > 0)
        {
            anim.SetBool("FoiA", true);
            ultimoMoveA = true;
            ultimoMoveD = false;
        }

        if (Input.GetKeyUp(KeyCode.A) && vida > 0)
        {
            anim.SetBool("FoiA", false);
        }

        if (Input.GetKeyDown(KeyCode.D) && vida > 0)
        {
            anim.SetBool("FoiD", true);
            ultimoMoveA = false;
            ultimoMoveD = true;
        }

        if (Input.GetKeyUp(KeyCode.D) && vida > 0)
        {
            anim.SetBool("FoiD", false);
        }

        if (tempoMortal >= 2)
        {
            vivencia = true;
            sprite.color = new Color(1f, 1f, 1f, 1f);
        }

        if (vida <= 0 && morreu == false)
        {
            Morreu();
            velocidade = 0;
            morreu = true;
            MostrarTelaDeMorte();
        }

        vidaText.text = "Vida: " + vida;
        if (tempoA >= 1f)
        {
            BalaA.text = "PodeAtirAr";
        }
        if (tempoA <= 0f)
        {
            BalaA.text = "CArregAndo";
        }
        if (tempoB >= 1f)
        {
            BalaB.text = "BoBeaBirar";
        }
        if (tempoB <= 0f)
        {
            BalaB.text = "BarreBanBo";
        }

        if (Input.GetKeyDown(KeyCode.L) && vida > 0 ) // Verifica se a tecla L foi pressionada e se o jogador derrotou um dos chefes
        {
            if (ultimoMoveA)
            {
                DashEsquerda();
            }
            else if (ultimoMoveD)
            {
                DashDireita();
            }
        }

        if (noDash)
        {
            if (ultimoMoveA)
            {
                transform.Translate(Vector3.left * velocidade * Time.deltaTime * 2);
            }
            else if (ultimoMoveD)
            {
                transform.Translate(Vector3.right * velocidade * Time.deltaTime * 2);
            }
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
                Tiro.Play();
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
                Tiro.Play();
            }
    }
    
}
private void OnCollisionStay2D(Collision2D dano)
{
    if (dano.gameObject.tag == danoInimigo && tempoMortal >= 2 && vivencia ==  true && morreu == false)
    {
            //danoInimigo == a tag que tu botar lá
        vida = vida - 1;
        vivencia = false;
        tempoMortal = 0;
        sprite.color = new Color(1f, 0, 0, 1f);

    }

}
    void MostrarTelaDeMorte()
    {
        telaDeMorte.SetActive(true);
        Time.timeScale = 0.7f;
    }

    private void Morreu()
    {

            anim.SetTrigger("MORREU");
            
    }
    private void DashEsquerda()
    {
        if (!noDash)
        {
            StartCoroutine(ExecutarDash(Vector3.left));
        }
    }

    private void DashDireita()
    {
        if (!noDash)
        {
            StartCoroutine(ExecutarDash(Vector3.right));
        }
    }

    private IEnumerator ExecutarDash(Vector3 direcao)
    {
        noDash = true;

        yield return new WaitForSeconds(tempoDash);

       noDash = false;
    }

}