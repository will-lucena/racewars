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
    private int currentHp;

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
}
