using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject efectoMuerte;
    public int daño = 1;
    public int valorPuntos = 2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            JugadorMovimiento jugador = collision.gameObject.GetComponent<JugadorMovimiento>();
            Vector2 direccion = collision.contacts[0].normal;

            if (direccion.y < -0.5f || jugador.estaAtacando)
            {
                Morir();
            }
            else
            {
                jugador.RecibirDaño(daño);
                GameManager.instancia?.SumarPuntos(-valorPuntos);
            }
        }
    }

    public void Morir()
    {
        if (efectoMuerte)
            Instantiate(efectoMuerte, transform.position, Quaternion.identity);

        GameManager.instancia?.SumarPuntos(valorPuntos);
        Destroy(gameObject);
    }

    public void RecibirDisparo()
    {
        Morir();
    }
}


