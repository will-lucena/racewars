using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAction : MonoBehaviour {

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform playerShootPosition;
    [SerializeField]
    private KeyCode key;
    [SerializeField]
    private GameObject parent;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(key))
        {
            Instantiate(bullet, parent.transform);
        }
    }
}
