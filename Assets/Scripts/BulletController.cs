using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    [SerializeField]
    private float movementSpeed;

    private void FixedUpdate()
    {
        transform.Translate(Vector2.down * movementSpeed * Time.deltaTime);
    }
}
