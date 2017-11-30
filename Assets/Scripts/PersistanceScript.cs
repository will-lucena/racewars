using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistanceScript : MonoBehaviour
{
    public static PersistanceScript INSTANCE;

    public Color player1Selection = Color.white;
    public Color player2Selection = Color.white;
    [HideInInspector] public Rect cam1Rect = new Rect(0f, 0f, 0.5f, 1f);
    [HideInInspector] public Rect cam2Rect = new Rect(0.5f, 0f, 0.5f, 1f);

    void Awake()
    {
        if (INSTANCE == null)
        {
            DontDestroyOnLoad(gameObject);
            INSTANCE = this;
        }   

        if (INSTANCE != this)
        {
            Destroy(gameObject);
        }
    }
}
