using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int maxHp;

    private int currentHp;
    private int playerNumber;
    private MovementController movement;
    private ShootAction fire;
    private CannonController cannon;
    private ArenaManager arenaManager;
    private BarController ammo;
    private BarController health;

    public void setup(ArenaManager manager)
    {
        movement = GetComponent<MovementController>();
        movement.setPlayerNumber(playerNumber);

        fire = GetComponent<ShootAction>();
        fire.setPlayerNumber(playerNumber);
        fire.setPlayer(GetComponent<PlayerController>());

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).transform.name == "Cannon")
            {
                cannon = transform.GetChild(i).transform.GetComponent<CannonController>();
            }
            if (transform.GetChild(i).transform.name == "AmmoBar")
            {
                ammo = transform.GetChild(i).transform.GetComponent<BarController>();
            }
            if (transform.GetChild(i).transform.name == "HealthBar")
            {
                health = transform.GetChild(i).transform.GetComponent<BarController>();
            }
        }
        cannon.setPlayerNumber(playerNumber);

        arenaManager = manager;

        if (playerNumber == 1)
        {
            GetComponent<SpriteRenderer>().color = PersistanceScript.INSTANCE.player1Selection;
        }

        if (playerNumber == 2)
        {
            GetComponent<SpriteRenderer>().color = PersistanceScript.INSTANCE.player2Selection;
        }
    }

    private void Start()
    {
        currentHp = maxHp;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("bullet"))
        {
            currentHp = currentHp - 3;
            Destroy(collision.gameObject);
            if (currentHp < 0)
            {
                arenaManager.SendMessage("iDie", gameObject);
            }
            else
            {
                health.SendMessage("action", 3);
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

    public void reload(float time)
    {
        StartCoroutine(reloadAnimation(time));
    }

    private IEnumerator reloadAnimation(float time)
    {
        float deltaTime = 0f;
        ammo.SendMessage("action", 1);
        while (deltaTime < time)
        {
            ammo.SendMessage("action", -Time.deltaTime);
            deltaTime += Time.deltaTime;
            yield return null;
        }
    }

    public void disable()
    {
        gameObject.SetActive(false);
    }
}
