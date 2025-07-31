using UnityEngine;

public class FondoInfinito : MonoBehaviour
{
    public Transform fondo1;
    public Transform fondo2;
    public Transform camara;

    private float anchoFondo;

    void Start()
    {
        if (camara == null)
            camara = Camera.main.transform;

        anchoFondo = fondo1.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {

        if (fondo1.position.x + anchoFondo < camara.position.x + 15f)
        {
            fondo1.position = new Vector3(
                fondo2.position.x + anchoFondo,
                fondo1.position.y,
                fondo1.position.z
            );
        }
    }
}


