using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShootAction : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private float reloadTime;

    private string fireButtonName;
    private bool isReloading;
    private int playerNumber;
    private PlayerController player;

    private void Start()
    {
        isReloading = false;
        fireButtonName = "Fire" + playerNumber;
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            player.SendMessage("quit");
        }

        if (playerNumber == 2)
        {
            if ((Input.GetButtonDown(fireButtonName) || Input.GetKeyDown(KeyCode.Joystick2Button7)) && !isReloading)
            {
                isReloading = true;
                Instantiate(bullet, shotPoint.position, shotPoint.rotation * Quaternion.Euler(0, 0, 0));
                StartCoroutine(reload(reloadTime));
                player.SendMessage("reload", reloadTime);
            }
        }

        if (playerNumber == 1)
        {
            if ((Input.GetButtonDown(fireButtonName) || Input.GetAxisRaw(fireButtonName) < 0) && !isReloading)
            {
                isReloading = true;
                Instantiate(bullet, shotPoint.position, shotPoint.rotation * Quaternion.Euler(0, 0, 0));
                StartCoroutine(reload(reloadTime));
                player.SendMessage("reload", reloadTime);
            }
        }
    }

    private IEnumerator reload(float time)
    {
        yield return new WaitForSeconds(time);
        isReloading = false;
    }

    public void setPlayerNumber(int number)
    {
        playerNumber = number;
    }

    public void setPlayer(PlayerController controller)
    {
        player = controller;
    }
}
