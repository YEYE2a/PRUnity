using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] itemPrefab;
    public float minTime = 1f;
    private Vector3 posicionInicial;
    public float maxTime = 2f;
    public float distanciaX = 5f;

    private Vector3 nextSpawnPos;
    private int indexActual = 0;
    public GameObject aguaPrefab;
    void Start()
    {
        posicionInicial = transform.position;
        nextSpawnPos = transform.position;
        nextSpawnPos.y = -4f; 
        StartCoroutine(SpawnCoRoutine(0));
    }
   
    public void ReposicionarAInicio()
    {
        StopAllCoroutines();
    transform.position = posicionInicial;
    nextSpawnPos = posicionInicial;
    nextSpawnPos.y = -4f;
    indexActual = 0;
    StartCoroutine(SpawnCoRoutine(0));
    }




IEnumerator SpawnCoRoutine(float waitTime)
{
    yield return new WaitForSeconds(waitTime);

    if (itemPrefab.Length == 0) yield break;

    nextSpawnPos.y = -4f;

    GameObject obj = Instantiate(itemPrefab[indexActual], nextSpawnPos, Quaternion.identity);
    obj.tag = "Destruible";

    if (aguaPrefab != null)
    {
        Vector3 posicionAgua = new Vector3(nextSpawnPos.x - 5, -4.5f, 100f);
        Instantiate(aguaPrefab, posicionAgua, Quaternion.identity).tag = "Destruible";
    }


    nextSpawnPos.x += distanciaX;

    indexActual++;
    if (indexActual >= itemPrefab.Length)
        indexActual = 0;

    float nextTime = Random.Range(minTime, maxTime);
    StartCoroutine(SpawnCoRoutine(nextTime));
}

}

