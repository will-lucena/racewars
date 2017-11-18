using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistanceScript : MonoBehaviour
{
    public static PersistanceScript INSTANCE;

    public Color player1Selection;
    public Color player2Selection;

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
