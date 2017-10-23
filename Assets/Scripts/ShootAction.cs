using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAction : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform shotPoint;
    [SerializeField]
    private KeyCode key;

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(key))
        {
            Instantiate(bullet, shotPoint.position, shotPoint.rotation * Quaternion.Euler(0, 0, 90));
        }
    }
}
