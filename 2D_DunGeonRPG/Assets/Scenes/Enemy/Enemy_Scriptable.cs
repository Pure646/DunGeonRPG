using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/Enemy_Anything")]
public class Enemy_Base : ScriptableObject
{
    public string weaponName;
    public float HealthPoint;
    public float ManaPoint;
    public float DamagePoint;
    public float Armor;
}
