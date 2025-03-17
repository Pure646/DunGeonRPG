using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathfString : MonoBehaviour
{
    public float num;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y))
        {
            MathfNum();
        }
    }
    void MathfNum()
    {
        //float Numble = Mathf.Abs(num);
        //Debug.Log(Numble);

        //float Numble = Mathf.Sign(num);
        //Debug.Log(Numble);

        //float NUmble = Mathf.Min(num, 1f, 5f, 65f, 123f, 125165f, 235f);
        //Debug.Log(NUmble);

        float degree = Mathf.Deg2Rad * 180;
        float pi = Mathf.PI;
        Debug.Log(degree);
        Debug.Log(pi);
        float radree = Mathf.Rad2Deg * pi;
        Debug.Log(radree);


    }
}
