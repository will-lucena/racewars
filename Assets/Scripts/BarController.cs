using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BarController : MonoBehaviour
{
    [SerializeField] private float maxPoints;
    [SerializeField] private Image currentBar;

    private float currentPoints;

	void Start ()
    {
        currentPoints = maxPoints;
        updateBar();
    }
	
    private void updateBar()
    {
        float ratio = currentPoints / maxPoints;

        if (ratio > 1f)
        {
            ratio = 1f;
        }
        else if (ratio < 0f)
        {
            ratio = 0f;
        }

        currentBar.rectTransform.localScale = new Vector3(1, ratio, 1);
        currentBar.color = Color.Lerp(Color.red, Color.green, ratio);
    }

    public void action(float valor)
    {
        currentPoints -= valor;
        updateBar();
    }

    public float getPoints()
    {
        return currentPoints;
    }
}
