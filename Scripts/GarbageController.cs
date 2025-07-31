using UnityEngine;

public class GarbageController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.CompareTag("Destruible") && !collision.name.ToLower().Contains("fondo"))
        {
            Destroy(collision.gameObject);
        }
    }
}

