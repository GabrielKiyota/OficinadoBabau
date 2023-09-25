using UnityEngine;

public class Laser : MonoBehaviour
{
    private Transform PlayerTransform;
    public float VelocidadeDoLaser;
    public float TempoDeVida;
    public int DanoDoLaser;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MirarNoPlayer();
        transform.Translate(  VelocidadeDoLaser * Time.deltaTime * Vector3.right);
        TempoDeVida -= Time.deltaTime;
        if (TempoDeVida <= 0)
        {
            Destroy(gameObject);
        }
    }
    void MirarNoPlayer()
    {
        Vector3 DirecaoDoLaser =  PlayerTransform.position - transform.position;

        float AnguloDoLaser = Mathf.Atan2(DirecaoDoLaser.y, DirecaoDoLaser.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, AnguloDoLaser );
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        
    }
}