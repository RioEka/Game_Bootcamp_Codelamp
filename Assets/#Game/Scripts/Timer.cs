using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    private bool isRed = false;
    //biar teksnya merah pas mau abis waktunya


    public void AddTime(float timeToAdd)
    {
        remainingTime += timeToAdd;
        //case kalau merah terus waktunya nambah jadi bisa reset ke putih
        if (remainingTime > 11 && isRed)
        {
            timerText.color = Color.white;
            isRed = false;
        }
    }
 


    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            if (remainingTime < 11 && !isRed)
            {
                timerText.color = Color.red;
                isRed = true;
                }
        }

        else
        {
            remainingTime = 0;
            //GameOver();
            //timerText.color = Color.red;
        }
        
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
