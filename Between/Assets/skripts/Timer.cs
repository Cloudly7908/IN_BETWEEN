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
    float Millisecond1;

    //int timeTime;
   
    

    [SerializeField] public Text timerText;

    private void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        //Millisecond = Mathf.FloorToInt(timeLeft += Time.deltaTime * 100);
        


        
       
        seconds = (float)(timer % 60);
        
        minutes = (int)((timer / 60) % 60);

        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00.00").Replace(".", ":"); ;
    }
    

}
