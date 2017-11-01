using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private GameObject target;
    private Vector3 offset = new Vector3(0, 0, -1);

    private void LateUpdate()
    {
        transform.position = new Vector3(
            transform.position.x + offset.x,
            transform.position.y + offset.y,
            -10);
    }

    public void setTarget(GameObject gameObject)
    {
        target = gameObject;
    }
}
