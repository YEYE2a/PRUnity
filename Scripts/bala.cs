using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidad = 10f;
    public float tiempoVida = 2f;

    void Start()
    {
        Destroy(gameObject, tiempoVida);
    }

    void Update()
    {
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colisión detectada con: " + other.name); 

        if (other.CompareTag("Enemigo"))
        {
            Enemy enemigo = other.GetComponent<Enemy>();
            if (enemigo != null)
            {
                Debug.Log("Disparo registrado al enemigo");
                enemigo.RecibirDisparo();
            }

            Destroy(gameObject);
        }
    }
}








