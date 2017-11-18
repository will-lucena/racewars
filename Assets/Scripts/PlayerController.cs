﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int maxHp;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Image fillImage;
    [SerializeField] private Color zeroHealthColor;
    [SerializeField] private Color fullHealthColor;
    [SerializeField] private Camera cam;
    private int currentHp;
    private int playerNumber;
    private MovementController movement;
    private ShootAction fire;
    private CannonController cannon;
    private ArenaManager arenaManager;

    public void setup(ArenaManager manager)
    {
        movement = GetComponent<MovementController>();
        movement.setPlayerNumber(playerNumber);

        fire = GetComponent<ShootAction>();
        fire.setPlayerNumber(playerNumber);

        for (int i = 0; i < transform.childCount - 1; i++)
        {
            if (transform.GetChild(i).transform.name == "Cannon")
            {
                cannon = transform.GetChild(i).transform.GetComponent<CannonController>();
                break;
            }
        }
        cannon.setPlayerNumber(playerNumber);

        cam.GetComponent<CameraController>().setTarget(gameObject);
        arenaManager = manager;
        
        //Modificar as cores dos jogadores TODO: entender como funciona e reimplementar
        /*
        m_ColoredPlayerText = "<color=#" + ColorUtility.ToHtmlStringRGB(m_PlayerColor) + ">PLAYER " + m_PlayerNumber + "</color>";

        MeshRenderer[] renderers = m_Instance.GetComponentsInChildren<MeshRenderer>();

        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = m_PlayerColor;
        }
        /**/
    }

    private void Start()
    {
        currentHp = maxHp;
        healthSlider.value = currentHp * 10;
        fillImage.color = Color.green;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("bullet"))
        {
            currentHp = currentHp - 3;
            Destroy(collision);
            if (currentHp < 0)
            {
                arenaManager.SendMessage("iDie", gameObject);
            }
            healthSlider.value = currentHp * 10;
            if (currentHp < maxHp * .7 && currentHp > maxHp * 0.3)
            {
                fillImage.color = Color.yellow;
            }
            else if (currentHp <= maxHp * 0.3)
            {
                fillImage.color = Color.red;
            }
        }
    }

    public int getHp()
    {
        return currentHp;
    }

    public void setPlayerNumber(int number)
    {
        playerNumber = number;
    }

    public int getPlayerNumber()
    {
        return playerNumber;
    }

    public void winMessage()
    {
        Debug.Log(playerNumber + " wins");
    }

    public void loseMessage()
    {
        Debug.Log(playerNumber + " lose");
        gameObject.SetActive(false);
    }
}
