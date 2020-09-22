using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour
{
    public float radius = 1f;

    public float cameraWidth;
    public float cameraHeight;
    // Start is called before the first frame update
    private void Awake()
    {
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Camera.main.aspect;
    }

    private void LateUpdate()
    {
        Vector3 position = transform.position;

        if (position.x > cameraWidth - radius)
        {
            position.x = cameraWidth - radius;
        }
        if (position.x < -cameraWidth + radius)
        {
            position.x = -cameraWidth + radius;
        }
        if (position.y > cameraHeight - radius)
        {
            position.y = cameraHeight - radius;
        }
        if (position.y > -cameraHeight + radius)
        {
            position.y = -cameraHeight + radius;
        }

        transform.position = position;
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying)
            return;

        Vector3 boundSize = new Vector3(cameraWidth * 2f, cameraHeight * 2f, 0.1f);

        Gizmos.DrawWireCube(Vector3.zero, boundSize);
    }

}