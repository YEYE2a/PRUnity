using System.Collections;
using UnityEngine;

public class spawnEnemigo : MonoBehaviour
{
    public GameObject[] enemigosPrefab;
    private Vector3 posicionInicial;
    public float distanciaX = 8f;
    public float minTiempo = 2f;
    public float maxTiempo = 4f;
    public Transform puntoReferenciaAltura;

    private Vector3 proximaPos;
    private int indexActual = 0;

    void Start()
    {
        posicionInicial = transform.position;
        proximaPos = transform.position;
        if (puntoReferenciaAltura != null)
            proximaPos.y = puntoReferenciaAltura.position.y;

        StartCoroutine(SpawnCORoutine(0f));
    }
  public void ReposicionarAInicio()
    {
        StopAllCoroutines();
        transform.position = posicionInicial;
        proximaPos = posicionInicial;

        if (puntoReferenciaAltura != null)
            proximaPos.y = puntoReferenciaAltura.position.y;

        indexActual = 0;
        StartCoroutine(SpawnCORoutine(0f));
    }


    IEnumerator SpawnCORoutine(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        if (enemigosPrefab.Length == 0) yield break;

        GameObject enemigo = Instantiate(enemigosPrefab[indexActual], proximaPos, Quaternion.identity);
        enemigo.tag = "Enemigo"; 

        proximaPos.x += distanciaX;
        indexActual = (indexActual + 1) % enemigosPrefab.Length;

        float siguienteTiempo = Random.Range(minTiempo, maxTiempo);
        StartCoroutine(SpawnCORoutine(siguienteTiempo));
    }
}
