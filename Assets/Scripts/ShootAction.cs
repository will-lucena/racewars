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
    [SerializeField] private Slider ammoSlider;
    [SerializeField] private Image fillImage;
    [SerializeField] private Color zeroAmmoColor;
    [SerializeField] private Color fullAmmoColor;
    private string fireButtonName;
    private bool isReloading;
    private int playerNumber;


    private void Start()
    {
        isReloading = false;
        ammoSlider.value = 1f;
        fillImage.color = Color.green;
        fireButtonName = "Fire" + playerNumber;
    }

    private void FixedUpdate()
    {
        if ((Input.GetButtonDown(fireButtonName) || Input.GetAxisRaw(fireButtonName) == -1) && !isReloading)
        {
            isReloading = true;
            Instantiate(bullet, shotPoint.position, shotPoint.rotation * Quaternion.Euler(0, 0, 0));
            StartCoroutine(reload(reloadTime));
            StartCoroutine(reloadAnimation(reloadTime));
        }
    }

    private IEnumerator reload(float time)
    {
        yield return new WaitForSeconds(time);
        isReloading = false;
    }

    private IEnumerator reloadAnimation(float time)
    {
        fillImage.color = Color.red;
        ammoSlider.value = .0f;
        yield return new WaitForSeconds(time * 0.3f);
        ammoSlider.value = 0.3f;
        yield return new WaitForSeconds(time * 0.3f);
        ammoSlider.value = 0.6f;
        fillImage.color = Color.yellow;
        yield return new WaitForSeconds(time * 0.3f);
        ammoSlider.value = 1f;
        fillImage.color = Color.green;
    }

    public void setPlayerNumber(int number)
    {
        playerNumber = number;
    }
}
