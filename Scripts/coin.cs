using UnityEngine;

public class Coin : MonoBehaviour
{
    public int valor = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instancia.SumarPuntos(valor);
            Destroy(gameObject);
        }
    }
}


