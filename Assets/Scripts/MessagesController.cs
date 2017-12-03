using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagesController : MonoBehaviour
{
    [SerializeField] private Text message;

    public void updateText()
    {
        message.text = "Player1 " + PersistanceScript.INSTANCE.player1Victories + " - " + PersistanceScript.INSTANCE.player2Victories + " Player2";
        message.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            GetComponentInParent<LoadScene>().loadScene(PersistanceScript.ArenaScene);
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            GetComponentInParent<LoadScene>().loadScene(PersistanceScript.MenuScene);
        }
    }
}
