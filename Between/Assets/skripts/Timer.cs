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
    int num1;
    private int timernum()
    {
        num1++;
        if (num1 >= 60)
        {
            num1 -= 60;
        }
        return num1;
    }

    [SerializeField] public Text timerText;

    private void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        Millisecond = Mathf.FloorToInt(timeLeft += Time.deltaTime * 100);
        Millisecond1 =


        
       
        seconds = (int)(timer % 60);
        minutes = (int)((timer / 60) % 60);
   
        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + timernum().ToString("00");
    }
    IEnumerator timer1()
    {

        int time = 0;
        while(true)
        {
            yield return new WaitForSeconds(0.1f);
            time++;
            if(time == 60)
            {
                time -= 60;
            }
            timernum();
        }
        


    }    

}
