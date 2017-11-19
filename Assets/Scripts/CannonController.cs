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

        //*
        if (playerNumber == 1)
        {
            GetComponent<SpriteRenderer>().color = PersistanceScript.INSTANCE.player1Selection;
        }

        if (playerNumber == 2)
        {
            GetComponent<SpriteRenderer>().color = PersistanceScript.INSTANCE.player2Selection;
        }
        /**/
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
