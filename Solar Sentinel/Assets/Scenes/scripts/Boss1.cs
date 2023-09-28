using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Boss1 : MonoBehaviour
{
   public GameObject LaserDoBoss1;
   public Transform localdodisparo;
  
   public float velocidadedoBoss1;
   public int vidaMaximaDoBoss1;
   public int vidaAtualDoBoss1;

   public float tempoMaximoEntreOsLasers;
   private Transform Target;

   public float tempoAtualDosLasers;
   // Start is called before the first frame update
   void Start()
   {
      Target = GameObject.FindGameObjectWithTag("Player").transform;
       vidaAtualDoBoss1 = vidaMaximaDoBoss1;
   }

   // Update is called once per frame
   void Update()
   {
       MovimentarBoss1();
       AtirarLaser();
   }

   private void MovimentarBoss1()
   {
       transform.position = Vector3.MoveTowards(transform.position, Target.position, 1f * Time.deltaTime);
       //transform.Translate(Vector3.down * velocidadedoBoss1 * Time.deltaTime);
   }


   private void AtirarLaser()
   {
       tempoAtualDosLasers -= Time.deltaTime;

       if(tempoAtualDosLasers <= 0)
       {
           Instantiate(LaserDoBoss1, localdodisparo.position, Quaternion.Euler(0f, 0f, 90f));
           tempoAtualDosLasers = tempoMaximoEntreOsLasers;
       }
   }

   public void MachucarBoss1(int danoParaReceber)
   {
       vidaAtualDoBoss1 -= danoParaReceber;

       if(vidaAtualDoBoss1 <= 0)
       {
          Destroy(this.gameObject);
       }
   }
}
