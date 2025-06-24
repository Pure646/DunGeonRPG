using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jaas : InterFace_2
{
    private int AddNumber;
    public int jackson
    {
        get
        {
            AddNumber++;
            return AddNumber;
        }
        set
        {
            AddNumber = value;
        }
    }
    public void GunFire()
    {
        Debug.Log($"{jackson}");
    }
    public void ResetNumber()
    {
        jackson = 0;
    }
}


public class Tutotial_4 : MonoBehaviour
{
    Jaas gun = new Jaas();

    private void Start()
    {
        gun.GunFire();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            gun.GunFire();
        }
        if(Input.GetKeyDown(KeyCode.J))
        {
            gun.ResetNumber();
        }
    }
}
