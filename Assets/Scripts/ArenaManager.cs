using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaManager : MonoBehaviour
{
    [SerializeField] private PlayerController[] players;
    [SerializeField] private GameObject tankPrefab;
    [SerializeField] private Transform[] spawnPoints;

	void Start ()
    {
        SpawnAllTanks();
    }
	
    private void SpawnAllTanks()
    {
        for (int i = 0; i < players.Length; i++)
        {
            
            players[i].setInstance(Instantiate(tankPrefab, spawnPoints[i].position, spawnPoints[i].rotation) as GameObject);
            players[i].setPlayerNumber(i+1);
            players[i].setup();
        }
    }
}
