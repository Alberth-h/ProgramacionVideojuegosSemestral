using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemymanager : MonoBehaviour
{
    public static Enemymanager Instance;
    //[SerializeField]
    //GameMode gameMode;

    void Awake()
    {
        if(!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //public GameMode CurrentGameMode{ get => gameMode; set => gameMode = value;}
}
