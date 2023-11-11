using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Boss : MonoBehaviour
{
    public EstadosBoss3 estadoAtual;
    public float vidaAtual = 100f;
    public float limiteTransicaoEstado2 = 50f;

    Transform player;
    public float Speed;

    public GameObject prefabAInstanciar;
    public Transform firepoint;
    public Transform firepoint2;

    public Text VidaBoss;


    public float intervaloDeInstanciacao = 2.0f;
    public float intervaloanimat = 2.5f;
    private float tempoPassadoDesdeInstanciacao = 0.0f;

    public Animator anim;

    private int animState = 0; // Inicialmente, o estado é 0

    public Player vida;

    public GameObject aura;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bala")
        {
            vidaAtual = vidaAtual- 1;
        }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(vidaAtual <= 0)
        {
            VidaBoss.text = " ";

        }
        if (vidaAtual > 0)
        {
            VidaBoss.text = "Vida Boss = " + vidaAtual;
        }

        if (estadoAtual == EstadosBoss3.estado1)
        {
            Update1();
            if (vidaAtual <= limiteTransicaoEstado2)
            {
                estadoAtual = EstadosBoss3.estado2;
            }
        }
        if (estadoAtual == EstadosBoss3.estado2)
        {
            Update2();

            if (vidaAtual <= 0)
            {
                animState = 2;
                anim.SetInteger("transition", animState);
            }
        }
    }

    void Update1()
    {
        // Movimentação
        Vector3 TargetPosition = player.position;
        TargetPosition.Set(TargetPosition.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, TargetPosition, Speed / 100);

        tempoPassadoDesdeInstanciacao += Time.deltaTime;

        // Verifica se pode atacar novamente com base no intervalo de instânciação
        if (tempoPassadoDesdeInstanciacao >= intervaloDeInstanciacao)
        {
            ataque();
            
        }

        if(tempoPassadoDesdeInstanciacao >= intervaloanimat)
        {
            animat();
        }



        // Define o estado da animação com base em animState
        anim.SetInteger("transition", animState);
    }

    
    void animat()
    {
        animState = 1;
        anim.SetInteger("transition", animState);
        StartCoroutine(RetornarAnimacaoAoEstado0());

    }
    void ataque()
    {


        if (prefabAInstanciar != null && firepoint != null)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, 190);
            Instantiate(prefabAInstanciar, firepoint.position, rotation);
        }

        if (prefabAInstanciar != null && firepoint2 != null)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, 170);
            Instantiate(prefabAInstanciar, firepoint2.position, rotation);
        }


        // Reseta o tempo desde a última instânciação
        tempoPassadoDesdeInstanciacao = 0.0f;

        // Agora, após o ataque, defina o estado da animação de volta para 0
       
    }

    IEnumerator RetornarAnimacaoAoEstado0()
    {
        // Espere um curto período de tempo (por exemplo, 1 segundo) antes de definir animState para 0.
        yield return new WaitForSeconds(1.1f);

        animState = 0;
    }


    void Update2()
    {
       if(vidaAtual <= limiteTransicaoEstado2)
        {
            aura.SetActive(true);
        }
    }

    public void Damage(int dmg)
    {
        vidaAtual -= dmg;
    }

    public enum EstadosBoss3
    {
        estado1, estado2
    }
}
