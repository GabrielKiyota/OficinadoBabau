using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Destroi o objeto quando colide com algo que possui Box Collider
        Destroy(gameObject);
    }
}
