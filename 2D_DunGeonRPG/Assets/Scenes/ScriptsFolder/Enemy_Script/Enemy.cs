using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private enum EnemyName
    {
        None,
    }

    [SerializeField] private Enemy_Base EnemyBase;
    private void Update()
    {
        
    }
    private void Dragon()
    {
        if (EnemyBase != null)
        {
            if(EnemyBase.Enemy_Name == "Dragon")
            {

            }
        }
    }
}