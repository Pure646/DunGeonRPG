using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing_0401
{
    private float[] Max = new float[10];
    private float AddNumber;
    public float Jex
    {
        get
        {
            for(int i = 0; i < 10; i++)
            {
                Max[i] = Random.Range(0, 10);
                Debug.Log(Max[i]);
                AddNumber += Max[i];
            }
            return AddNumber;
        }
        set
        {
            AddNumber = 0;
        }
    }
}
public class Testing_04 : MonoBehaviour
{

    public float Number_1
    {
        get
        {
            Debug.Log("Get");
            Number_2++;
            return Number_2;
        }
        set
        {
            Debug.Log("Set");
            //Number_2 = value;
        }
    }
    private float Number_2;

    //private float Number_3 = Number_1;                        // 인스턴스가 완전히 생성되기 전이고, Unity에서는 이걸 허용하지 않습니다.
    private Testing_0401 numll = new Testing_0401();

    private void Start()
    {
        float Number_3 = Number_1;
        Number_1 = Number_3;
}
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(Number_1);
            Debug.Log(Number_2);
        }
        if(Input.GetKeyDown(KeyCode.T))
        {
            numll.Jex = Number_1;
            Debug.Log(numll.Jex);
            
        }
    }
}
