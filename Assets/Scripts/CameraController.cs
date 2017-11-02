using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private Vector3 offset = new Vector3(0, 0, -1);
    private static int seed = 0;

    private void Start()
    {
        GetComponent<Camera>().rect = new Rect(seed * 0.5f, 0f, 0.5f, 1f);
        updateSeed();
    }

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

    private static void updateSeed()
    {
        seed++;
    }

    public int getSeed()
    {
        return seed;
    }
}
