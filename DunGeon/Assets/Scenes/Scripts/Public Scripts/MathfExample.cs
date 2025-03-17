using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathfExample : MonoBehaviour
{
    [SerializeField] private float intTime;
    [SerializeField] private float value;
    
    void Update()
    {
        TimeSet();
        mathfPingpong();
    }

    private void TimeSet()
    {
        intTime = (int)Time.time;
    }
    private void mathfPingpong()
    {
        value = Mathf.PingPong(intTime, 9f);
        Debug.Log(value);
    }
}
