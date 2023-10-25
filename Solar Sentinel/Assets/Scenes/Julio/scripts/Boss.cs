using UnityEngine;

public class Boss : MonoBehaviour
{
    public EstadosBoss3 estadoAtual;
    public float Speed;
    public float tempoEntreTiros = 3f;
    public float velocidadeDoTiro = 3f;
    public GameObject tiroPrefab;

    Transform player;
    float tempoUltimoTiro;
    Animator anim;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        tempoUltimoTiro = Time.time;
        anim = GetComponent<Animator>(); // Adiciona esta linha para obter o componente Animator
    }

    void Update()
    {
        if (estadoAtual == EstadosBoss3.estado1)
        {
            Update1();
        }
        else if (estadoAtual == EstadosBoss3.estado2)
        {
            Update2();
        }
    }

    void Update1()
    {
        Vector3 TargetPosition = player.position;
        TargetPosition.Set(TargetPosition.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, TargetPosition, Speed / 100);

        if (Time.time - tempoUltimoTiro > tempoEntreTiros)
        {
            // Ativa a animação "attack"
            anim.SetTrigger("Attack");

            GameObject novoTiro = Instantiate(tiroPrefab, transform.position, Quaternion.identity);
            Rigidbody tiroRigidbody = novoTiro.GetComponent<Rigidbody>();
            tiroRigidbody.velocity = transform.forward * velocidadeDoTiro;

            // Destroi o tiro após 2 segundos
            Destroy(novoTiro, 2f);

            tempoUltimoTiro = Time.time;  // Atualiza o tempo do último tiro
        }
    }

    void Update2()
    {
        // Implemente o comportamento para o estado2, se necessário
    }
}

public enum EstadosBoss3
{
    estado1, estado2
}
