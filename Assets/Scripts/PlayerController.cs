using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    [SerializeField] private int maxHp;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Image fillImage;
    [SerializeField] private Color zeroHealthColor;
    [SerializeField] private Color fullHealthColor;
    [SerializeField] private Transform spawnPoint;
    private int currentHp;
    private GameObject instance;
    private int playerNumber;


    private MovementController movement;
    private ShootAction shooting;

    public void setup()
    {
        movement = instance.GetComponent<MovementController>();
        shooting = instance.GetComponent<ShootAction>();
        movement.setPlayerNumber(playerNumber);
        shooting.setPlayerNumber(playerNumber);

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

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("bullet"))
        {
            currentHp -= 3;
            print(currentHp);
            Destroy(collision);
            if (currentHp < 0)
            {
                Destroy(gameObject);
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

    public void setInstance(GameObject gameObject)
    {
        instance = gameObject;
    }

    public GameObject getInstance()
    {
        return instance;
    }

    public Transform getSpawnPoint()
    {
        return spawnPoint;
    }

    public void setPlayerNumber(int number)
    {
        playerNumber = number;
    }
}
