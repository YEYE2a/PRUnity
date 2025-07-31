using UnityEngine;

public class Camera2D : MonoBehaviour
{
    public Transform targetPlayer;
    private float zInicial;
    private float yFija;

    void Start()
    {
        zInicial = transform.position.z;
        yFija = transform.position.y; 
    }

    void Update()
    {
        if (targetPlayer != null)
        {
            transform.position = new Vector3(targetPlayer.position.x, yFija, zInicial);
        }
    }
}


