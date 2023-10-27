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

    public GameObject prefabAInstanciar; // Arraste o prefab que voc� deseja instanciar para esse campo no Unity Inspector.
    public Transform firepoint;
    public Transform firepoint2; // Arraste o segundo objeto "firepoint" para esse campo no Unity Inspector.
                                 // Arraste o objeto "firepoint" para esse campo no Unity Inspector.
    public float intervaloDeInstanciacao = 5.0f;
    private float tempoPassadoDesdeInstanciacao = 0.0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
        // Movimenta��o
        Vector3 TargetPosition = player.position;
        TargetPosition.Set(TargetPosition.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, TargetPosition, Speed / 100);

        // Ataque
        tempoPassadoDesdeInstanciacao += Time.deltaTime;

        if (tempoPassadoDesdeInstanciacao >= intervaloDeInstanciacao)
        {
            // Rota��o desejada (90 graus em torno do eixo Z)
            Quaternion rotation = Quaternion.Euler(0, 0, 90);

            // Instancia o prefab no primeiro "firepoint" com a rota��o especificada
            if (prefabAInstanciar != null && firepoint != null)
            {
                Instantiate(prefabAInstanciar, firepoint.position, rotation);
            }

            // Instancia o prefab no segundo "firepoint" com a mesma rota��o
            if (prefabAInstanciar != null && firepoint2 != null)
            {
                Instantiate(prefabAInstanciar, firepoint2.position, rotation);
            }

            tempoPassadoDesdeInstanciacao = 0.0f;
        }
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
