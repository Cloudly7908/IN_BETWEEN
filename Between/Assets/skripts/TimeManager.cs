using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
 
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.F))
        {
            Time.timeScale = 0.10f;
        }
        else
            Time.timeScale = 1;
    }
}
