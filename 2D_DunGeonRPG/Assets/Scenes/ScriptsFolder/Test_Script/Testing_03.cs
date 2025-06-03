using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing_03 : MonoBehaviour
{
    [Range(0f, 100000f)]
    public int Unity;
    [Space(100)]
    public int World = 0;
    [Multiline(5)]
    public string Name;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Unity >= 50000)
            {
                Debug.Log($"{Unity} | {World}");
            }
            else
            {
                Debug.Log(Unity);
            }
        }
        if(Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log(Name);
        }
    }
}
