using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaManager : MonoBehaviour
{
    [SerializeField] private GameObject tankPrefab;
    [SerializeField] private Transform[] spawnPoints;

    private GameObject[] players;

    void Start ()
    {
        players = new GameObject[2];
        SpawnAllTanks();
    }
	
    private void SpawnAllTanks()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i] = Instantiate(tankPrefab, spawnPoints[i].position, spawnPoints[i].rotation) as GameObject;
            players[i].SetActive(false);
            players[i].GetComponent<PlayerController>().setPlayerNumber(i + 1);
            players[i].GetComponent<PlayerController>().setup(this);
            players[i].SetActive(true);
        }
    }

    private void endGame(GameObject player)
    {
        if (player.GetComponent<PlayerController>().getPlayerNumber() == 1)
        {
            PersistanceScript.INSTANCE.player2Victories++;
        }
        else
        {
            PersistanceScript.INSTANCE.player1Victories++;
        }
        GetComponentInParent<MessagesController>().updateText();
    }

    public void iDie(GameObject player)
    {
        foreach(GameObject p in players)
        {
            p.GetComponent<PlayerController>().disable();
        }
        endGame(player);
    }

    public void endLoop()
    {
        GetComponentInParent<LoadScene>().SendMessage("loadScene", "Menu");
    }
}
