using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] enemies;

    private float[] _area1_x = {-27f, -3.5f};
    private float[] _area1_z = {-1.5f, 13f};

    private float[] _area2_x = {-27f, -14f};
    private float[] _area2_z = {31f, 57f};

    private float[] _area3_x = {15f, 26f};
    private float[] _area3_z = {28.5f, 45f};

    private float[] _area4_x = {15f, 27f};
    private float[] _area4_z = {-5f, 10f};

    private void Awake()
    {
        //Area 1
        Instantiate(enemies[Random.Range(0, enemies.Length)], new Vector3(Random.Range(_area1_x[0], _area1_x[1]), 0f, Random.Range(_area1_z[0], _area1_z[1])), Quaternion.Euler(new Vector3(0, 180, 0)));

        //Area 2
        Instantiate(enemies[Random.Range(0, enemies.Length)], new Vector3(Random.Range(_area2_x[0], _area2_x[1]), 0f, Random.Range(_area2_z[0], _area2_z[1])), Quaternion.Euler(new Vector3(0, 180, 0)));

        //Area 3
        Instantiate(enemies[Random.Range(0, enemies.Length)], new Vector3(Random.Range(_area3_x[0], _area3_x[1]), 0f, Random.Range(_area3_z[0], _area3_z[1])), Quaternion.Euler(new Vector3(0, 180, 0)));

        //Area 4
        Instantiate(enemies[Random.Range(0, enemies.Length)], new Vector3(Random.Range(_area4_x[0], _area4_x[1]), 0f, Random.Range(_area4_z[0], _area4_z[1])), Quaternion.Euler(new Vector3(0, 180, 0)));

    }

    //void CheckIfIsInBattle()
    //{
    //    Scene currentScene = SceneManager.GetActiveScene();
    //    string sceneName = currentScene.name;
//
    //    if (sceneName == "battle") 
    //    {
    //        Debug.Log("Jalo");
    //    }
    //}

    //void SetPositionInBattle()
    //{
    //    transform.position = new Vector3(12.18f, 43.2338f, 5.33f);
    //    transform.rotation = Quaternion.Euler(new Vector3(0.0f, 209.0f, 0.0f));
    //}
}
