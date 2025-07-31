using UnityEngine;

public class UIFollowCamera : MonoBehaviour
{
    public Transform cam;
    public Vector3 offset;

    void LateUpdate()
    {
        if (cam != null)
            transform.position = cam.position + offset;
    }
}

