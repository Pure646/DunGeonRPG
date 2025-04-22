using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private enum DunGeonRPG_Enemy
    {
        //Neutral_,
        None,
        Goblin,
        GiantGoblin,
    }
    private DunGeonRPG_Enemy Enum_Enemy;

    private List<int> Enemy_Count = new List<int>();
    private List<string> Enemy_Name = new List<string>();
    private List<float> Enemy_Health = new List<float>();

    private void Update()
    {
        Enemy_Data();
    }
    private void Enemy_Data()
    {
        if(Enemy_Count.Count > 0)
        {
            for (int i = 0; i < Enemy_Count.Count; i++)
            {
                switch (Enum_Enemy)
                {
                    case DunGeonRPG_Enemy.Goblin:
                        Enemy_Count[i] = i + 1;
                        Enemy_Name[i] = $"Goblin_{i + 1}";
                        Enemy_Health[i] = 10;
                        break;
                    case DunGeonRPG_Enemy.GiantGoblin:
                        Enemy_Count[i] = i + 1;
                        Enemy_Name[i] = $"GiantGoblin_{i + 1}";
                        Enemy_Health[i] = 100;
                        break;
                }
            }
        }
    }
}