using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShootAction : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private KeyCode key;
    [SerializeField] private float reloadTime;
    [SerializeField] private Slider ammoSlider;
    [SerializeField] private Image fillImage;
    [SerializeField] private Color zeroAmmoColor;
    [SerializeField] private Color fullAmmoColor;
    private bool isReloading = false;

    private void Start()
    {
        ammoSlider.value = 1f;
        fillImage.color = Color.green;
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(key) && !isReloading)
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
}
