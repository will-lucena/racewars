using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float movementSpeed;
    private int playerNumber = 1;
    private string movementAxisName;
    private string rotationAxisName;
    private float movementValue;
    private float rotationValue;

    void Start()
    {
        movementAxisName = "Vertical" + playerNumber;
        rotationAxisName = "Horizontal" + playerNumber;
    }

    private void Update()
    {
        movementValue = Input.GetAxis(movementAxisName);
        rotationValue = Input.GetAxis(rotationAxisName);
    }

    private void FixedUpdate()
    {
        move();
        rotate();
    }

    private void move()
    {
        transform.Translate(Vector2.down * movementSpeed * Time.deltaTime * movementValue);
    }

    private void rotate()
    {
        transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime * rotationValue);
    }

    public void setPlayerNumber(int number)
    {
        playerNumber = number;
    }
}
