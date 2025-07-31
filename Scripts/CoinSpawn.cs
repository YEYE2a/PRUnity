using System.Collections;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public GameObject coinPrefab;
    public float spawnInterval = 2f;
    private Vector3 posicionInicial;
    public float distanciaX = 6f;

    private Vector3 nextSpawnPos;

    void Start()
    {
        posicionInicial = transform.position;
        nextSpawnPos = transform.position;
        nextSpawnPos.y = -2f; 
        StartCoroutine(SpawnCoins());
    }
    public void ReposicionarAInicio()
    {
        StopAllCoroutines();
    transform.position = posicionInicial;
    nextSpawnPos = posicionInicial;
    nextSpawnPos.y = -2f;
    StartCoroutine(SpawnCoins());
    }

    IEnumerator SpawnCoins()
    {
        while (true)
        {
            Instantiate(coinPrefab, nextSpawnPos, Quaternion.identity);
            nextSpawnPos.x += distanciaX;
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
