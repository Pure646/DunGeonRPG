using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Img : MonoBehaviour
{
    private Enemy enemy;
    private GameObject Slime;
    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        { 

        }
    }
    private void MonsterSpawn()
    {

    }
}
