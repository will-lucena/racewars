using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsSceneController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            GetComponentInParent<LoadScene>().loadScene(PersistanceScript.SelectionScene);
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Escape))
        {
            GetComponentInParent<LoadScene>().loadScene(PersistanceScript.MenuScene);
        }
    }
}
