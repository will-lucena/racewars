using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementLetters : MonoBehaviour {

    //ajustar speed de rotação
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float movementSpeed;

    // Use this for initialization
    void Start () {
        	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("HorizontalLetters") != 0)
        {
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime * Input.GetAxisRaw("Horizontal"));
            print(transform.rotation);
        }

        if (Input.GetAxisRaw("VerticalLetters") != 0)
        {
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical"));
            print(transform.position);
        }
    }
}
