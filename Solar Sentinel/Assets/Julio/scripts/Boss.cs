using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public EstadosBoss3 estadoAtual;
    public float vidaMaxima = 100f;
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
    private bool podeAtacar = true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent <Animator>();
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
        anim.SetInteger("transition", 0);

        tempoPassadoDesdeInstanciacao += Time.deltaTime;

        // Verifica se pode atacar novamente com base no intervalo de instânciação
        if (tempoPassadoDesdeInstanciacao >= intervaloDeInstanciacao && podeAtacar)
        {
            ataque();
            anim.SetInteger("transition", 1);
        }
    }

    void ataque()
    {
        // Ataque
        Quaternion rotation = Quaternion.Euler(0, 0, 90);

        if (prefabAInstanciar != null && firepoint != null)
        {
            Instantiate(prefabAInstanciar, firepoint.position, rotation);
        }

        if (prefabAInstanciar != null && firepoint2 != null)
        {
            Instantiate(prefabAInstanciar, firepoint2.position, rotation);
        }

        // Reseta o tempo desde a última instânciação e impede mais ataques até o intervalo terminar
        tempoPassadoDesdeInstanciacao = 0.0f;
        podeAtacar = false;
        StartCoroutine(PermitirAtacarNovamente());
    }

    IEnumerator PermitirAtacarNovamente()
    {
        yield return new WaitForSeconds(intervaloDeInstanciacao);
        podeAtacar = true; // Permite atacar novamente
    }

    void Update2()
    {
        // Implemente o comportamento do estado2 aqui.
    }

    public enum EstadosBoss3
    {
        estado1, estado2
    }
}
