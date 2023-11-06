using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss1 : MonoBehaviour
{
   public GameObject LaserDoBoss1;
   public Transform localdodisparo,localdodisparo2;
   public EstadoDoboss1 atual;
   public float velocidadeDeRotacao;
   public int multiplicador;
  
   public float velocidadedoBoss1;
   public int vidaMaximaDoBoss1;
   public int vidaAtualDoBoss1;

   public float tempoMaximoEntreOsLasers;
   private Transform Target;

   public float tempoAtualDosLasers;

   public AudioSource Leser;

   public Image barraDeVida;
   
   // Start is called before the first frame update
   void Start()
   {
      Target = GameObject.FindGameObjectWithTag("Player").transform;
       vidaAtualDoBoss1 = vidaMaximaDoBoss1;
   }

   // Update is called once per frame
   void Update()
   {
       if (atual == EstadoDoboss1.estado1)
       {
           UpdateEstado1();
       }

       if (atual == EstadoDoboss1.estado2)
       {
           UpdateEstado2();
       }
   }

   void UpdateEstado1()
   {
       MovimentarBoss1();
       AtirarLaser();
   }

   void UpdateEstado2()
   {
      transform.Rotate(0,0,velocidadeDeRotacao * Time.deltaTime);
   }
   private void MovimentarBoss1()
   {
       Vector3 movimentar = new Vector3(transform.position.x, Target.position.y);
       transform.position = Vector3.Lerp(transform.position, movimentar, multiplicador * Time.deltaTime);
       //transform.Translate(Vector3.down * velocidadedoBoss1 * Time.deltaTime);
   }


   private void AtirarLaser()
   {
       tempoAtualDosLasers -= Time.deltaTime;

       if(tempoAtualDosLasers <= 0)
       {
           Instantiate(LaserDoBoss1, localdodisparo.position, Quaternion.Euler(0f, 0f, 90f));
           tempoAtualDosLasers = tempoMaximoEntreOsLasers;
           
           Instantiate(LaserDoBoss1, localdodisparo2.position, Quaternion.Euler(0f, 0f, 90f));
           Leser.Play();
       }
   }

   public void MachucarBoss1(int danoParaReceber)
   {
       vidaAtualDoBoss1 -= danoParaReceber;

       if (vidaAtualDoBoss1 <= vidaMaximaDoBoss1 / 2)
       {
           atual = EstadoDoboss1.estado2;
       }
       barraDeVida.fillAmount = vidaAtualDoBoss1 / vidaMaximaDoBoss1;

       if(vidaAtualDoBoss1 <= 0)
       {
          Destroy(this.gameObject);
       }
   }
}

public enum EstadoDoboss1
{
    estado1, estado2
}
