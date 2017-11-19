using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionScript : MonoBehaviour
{
    [SerializeField] private GameObject[] characters;
    [SerializeField] private GameObject[] playerSelection;
    private float delay;

    private int player1CharSelected;
    private int player2CharSelected;
    private float player1timePassed;
    private float player2timePassed;

    private static string PLAYER1_AXIS = "Selection1";
    private static string PLAYER2_AXIS = "Selection2";

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
        delay = 0.2f;
        player1timePassed = 0.3f;
        player2timePassed = 0.3f;
    }
	
	void Update ()
    {
        if (player1timePassed > delay)
        {
            player1CharSelected = changeSelectionPosition(0, player1CharSelected, (int)Input.GetAxisRaw(PLAYER1_AXIS));
            player1timePassed = 0;
        }

        if (player2timePassed > delay)
        {
            player2CharSelected = changeSelectionPosition(1, player2CharSelected, (int)Input.GetAxisRaw(PLAYER2_AXIS));
            player2timePassed = 0;
        }

        player1timePassed += Time.deltaTime;
        player2timePassed += Time.deltaTime;
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

    public void startGame()
    {
        PersistanceScript.INSTANCE.player1Selection = characters[player1CharSelected].GetComponent<Image>().color;
        PersistanceScript.INSTANCE.player2Selection = characters[player2CharSelected].GetComponent<Image>().color;

        new LoadScene().loadScene("Game");
    }
}
