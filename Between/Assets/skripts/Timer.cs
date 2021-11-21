using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    float timer;
    float Millisecond;
    float seconds;
    float minutes;
    float timeLeft = 15f;
    


    [SerializeField] Text timerText;

    private void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        Millisecond = Mathf.FloorToInt(timeLeft += Time.deltaTime * 100);
        Debug.Log(Millisecond);
       if (Millisecond > 60 )
       {
            Millisecond = 0.00f;
       }
        seconds = (int)(timer % 60);
        minutes = (int)((timer / 60) % 60);
   
        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + Millisecond.ToString("00");
    }

}
