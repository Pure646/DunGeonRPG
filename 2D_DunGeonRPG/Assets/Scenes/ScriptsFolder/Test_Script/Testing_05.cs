using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Testing_05 : MonoBehaviour
{
    public Text GameTime_Tx;
    public Text NowTime_Tx;

    private DateTime RealTime;
    private float timer;

    private int hour = 0;
    private int min = 0;
    private float sec = 0;
    private string mils = "";
    private int Count = 0;
    private void Start()
    {
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 0)
        {
            //RealTime = DateTime.Now;
            NowTime_Tx.text = $"{DateTime.Now.ToString("HH:mm:ss")}";
            timer = -1f;
        }
        sec = (float)(Time.realtimeSinceStartup - (60 * Count));
        if (sec >= 60)
        {
            sec -= 60f;
            min++;
            Count++;
        }
        if(min >= 60)
        {
            min = 0;
            hour++;
        }
        string PointSec = (sec - Mathf.FloorToInt(sec)).ToString("F3").Substring(2);
        GameTime_Tx.text = $"{hour.ToString("D2")} : {min.ToString("D2")} : {Mathf.FloorToInt(sec).ToString("D2")}.{PointSec}";
    }
}
