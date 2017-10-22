using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    [SerializeField]
    private float movementSpeed;

    private Transform spawnPosition;

	// Use this for initialization
	void Start () {
        spawnPosition = transform;
        print("bullet spawn: " + spawnPosition.position);
	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.down * movementSpeed * Time.deltaTime, spawnPosition);

        if ()
    }
}
