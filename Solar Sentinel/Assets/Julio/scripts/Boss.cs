using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public float intervaloDeInstanciacao = 2.0f;
    private float tempoPassadoDesdeInstanciacao = 0.0f;

    public Animator anim;

    private int animState = 0; // Inicialmente, o estado é 0

    public player vida;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            vida.vida = vida.vida - 1;
        }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
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

        // Define o estado da animação com base em animState
        anim.SetInteger("transition", animState);
    }

    
    
    void ataque()
    {
        // Ataque
        Quaternion rotation = Quaternion.Euler(0, 0, 180);

        if (prefabAInstanciar != null && firepoint != null)
        {
            Instantiate(prefabAInstanciar, firepoint.position, rotation);
        }

        if (prefabAInstanciar != null && firepoint2 != null)
        {
            Instantiate(prefabAInstanciar, firepoint2.position, rotation);
        }

        // Defina o estado da animação para 1
        animState = 1;

        // Reseta o tempo desde a última instânciação
        tempoPassadoDesdeInstanciacao = 0.0f;

        // Agora, após o ataque, defina o estado da animação de volta para 0
        StartCoroutine(RetornarAnimacaoAoEstado0());
    }

    IEnumerator RetornarAnimacaoAoEstado0()
    {
        // Espere um curto período de tempo (por exemplo, 1 segundo) antes de definir animState para 0.
        yield return new WaitForSeconds(1.1f);

        animState = 0;
    }


    void Update2()
    {
        // Implemente o comportamento do estado2 aqui.
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
