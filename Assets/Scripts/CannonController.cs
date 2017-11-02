using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private int playerNumber;
    private string rotationAxisName;
    private float rotationValue;

    void Start()
    {
        rotationAxisName = "Cannon" + playerNumber;
    }

    private void Update()
    {
        rotationValue = Input.GetAxis(rotationAxisName);
    }

    private void FixedUpdate()
    {
        rotate();
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
