using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public EstadosBoss3 estadoAtual;

    Transform player;
    public float Speed;

        void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (estadoAtual == EstadosBoss3.estado1) 
        {
            Update1();
        }
        if (estadoAtual == EstadosBoss3.estado2)
        {
            Update2();
        }
    }
    void Update1() 
    {
        Vector3 TargetPosition = player.position;
        TargetPosition.Set(TargetPosition.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, TargetPosition, Speed/100);
    }

    void Update2()
    {

    }

}
public enum EstadosBoss3 
{
    estado1,estado2
}