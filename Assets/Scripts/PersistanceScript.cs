using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistanceScript : MonoBehaviour
{
    public static PersistanceScript INSTANCE;

    public Color player1Selection = Color.white;
    public Color player2Selection = Color.white;
    public int player1Victories = 0;
    public int player2Victories = 0;
    [HideInInspector] public Rect cam1Rect = new Rect(0f, 0f, 0.5f, 1f);
    [HideInInspector] public Rect cam2Rect = new Rect(0.5f, 0f, 0.5f, 1f);
    [HideInInspector] public static string MenuScene = "Menu";
    [HideInInspector] public static string SelectionScene = "Character Selection";
    [HideInInspector] public static string ArenaScene = "Arena";
    [HideInInspector] public static string ControllersScene = "Controls";

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
