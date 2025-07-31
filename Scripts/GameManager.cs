using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;
    public SpawnManager spawnManager;

    private int puntaje = 0;

    public TMP_Text textoPuntaje;

    void Awake()
    {
        if (instancia == null) instancia = this;
        else Destroy(gameObject);
    }

    public void SumarPuntos(int cantidad)
    {
        puntaje += cantidad;
        textoPuntaje.text = "Puntos: " + puntaje;
    }
    public void ReiniciarPuntaje()
    {
        puntaje = 0;
        textoPuntaje.text = "Puntos: " + puntaje;
    }

}


