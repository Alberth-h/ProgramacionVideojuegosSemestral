using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{    
    void Awake()
    {

    }

    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Hero"))
        {
            SceneManager.LoadScene(1);
            //Instantiate(gameObject, new Vector3(12.18f, 43.23f, 5.33f), Quaternion.Euler(new Vector3(0, 209, 0)));
            //Destroy(gameObject);
        }
    }

    //void SetPositionInBattle()
    //{
    //    transform.position = new Vector3(12.18f, 43.2338f, 5.33f);
    //    transform.rotation = Quaternion.Euler(new Vector3(0.0f, 209.0f, 0.0f));
    //}
}
