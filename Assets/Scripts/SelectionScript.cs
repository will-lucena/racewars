using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionScript : MonoBehaviour
{
    [SerializeField] private GameObject[] characters;
    [SerializeField] private GameObject[] playerSelection;

    private int player1CharSelected;
    private int player2CharSelected;

    // Use this for initialization
    void Start ()
    {
        playerSelection[0].transform.position = new Vector3(characters[0].transform.position.x,
                                                                characters[0].transform.position.y + 6.4f,
                                                                characters[0].transform.position.y);

        player1CharSelected = 0;

        playerSelection[1].transform.position = new Vector3(characters[0].transform.position.x,
                                                                characters[0].transform.position.y + 6.4f,
                                                                characters[0].transform.position.y);

        player2CharSelected = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            player1CharSelected = changeSelectionPosition(0, player1CharSelected, 1);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            player1CharSelected = changeSelectionPosition(0, player1CharSelected, -1);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            player2CharSelected = changeSelectionPosition(1, player2CharSelected, 1);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            player2CharSelected = changeSelectionPosition(1, player2CharSelected, -1);
        }

    }

    private int changeSelectionPosition(int playerIndex, int characterIndex, int offset)
    {
        int index = (characterIndex + offset) % 4;

        if (index < 0)
        {
            index = 3;
        }
        playerSelection[playerIndex].transform.position = new Vector3(characters[index].transform.position.x, characters[index].transform.position.y + 6.3f, 0);
        return index;
    }
}
