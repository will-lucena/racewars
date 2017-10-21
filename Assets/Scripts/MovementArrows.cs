using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementArrows : MonoBehaviour {

    //ajustar speed de rotação
    [SerializeField]
    float rotationSpeed;
    [SerializeField]
    float movementSpeed;

	// Use this for initialization
	void Start () {
        	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("HorizontalArrows") != 0)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime * Input.GetAxisRaw("Horizontal"));
            print(transform.rotation);
        }

        if (Input.GetAxisRaw("VerticalArrows") != 0)
        {
            transform.Translate(Vector2.up * movementSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical"));
            print(transform.position);
        }
    }
}
