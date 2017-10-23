using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementArrows : MonoBehaviour
{
    //ajustar speed de rotação
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float movementSpeed;

    void Start()
    {

    }

    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("HorizontalArrows") != 0)
        {
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime * Input.GetAxisRaw("Horizontal"));
        }

        if (Input.GetAxisRaw("VerticalArrows") != 0)
        {
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical"));
        }
    }
}
