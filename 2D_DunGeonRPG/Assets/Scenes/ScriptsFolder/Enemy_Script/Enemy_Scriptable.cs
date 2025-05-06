using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/Enemy_Anything")]
public class Enemy_Base : ScriptableObject
{
    public string Enemy_Name;       // 이름
    public string Enemy_Type;       // 속성
    public float AttackDamge;       // 공격력
    public float Armor;             // 방어력
    public float Speed;             // 이동속도

    public string Information;       // 정보
}
