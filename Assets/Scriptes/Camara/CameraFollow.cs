using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    float offsetX;

    private void Start()
    {
        if (target == null)
        {
            return;
        }

        offsetX = transform.position.x - target.position.x;
    }


    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position;
        desiredPosition.x = target.position.x + offsetX;
        desiredPosition = new Vector3(desiredPosition.x, desiredPosition.y, -10);
        transform.position = desiredPosition;
    }

}
