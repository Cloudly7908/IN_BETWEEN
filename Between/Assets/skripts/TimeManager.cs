using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float Speed = 0.10f;
    public GameObject watch;
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.F))
        {
            Time.timeScale = Speed;
            watch.SetActive(true);
        }
        else 
        {
            Time.timeScale = 1;
            watch.SetActive(false);
        }

    }
}
