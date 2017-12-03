using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            GetComponentInParent<LoadScene>().loadScene(PersistanceScript.SelectionScene);
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            GetComponentInParent<LoadScene>().quit();
        }
    }
}
