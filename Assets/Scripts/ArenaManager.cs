using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaManager : MonoBehaviour {

    [SerializeField] private PlayerController[] players;
    [SerializeField] private GameObject tankPrefab;
    

	// Use this for initialization
	void Start () {
        SpawnAllTanks();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void SpawnAllTanks()
    {
        // For all the tanks...
        for (int i = 0; i < players.Length; i++)
        {
            // ... create them, set their player number and references needed for control.
            players[i].setInstance(Instantiate(tankPrefab, players[i].getSpawnPoint().position, players[i].getSpawnPoint().rotation) as GameObject);
            players[i].setPlayerNumber(i+1);
            players[i].setup();
        }
    }
}
