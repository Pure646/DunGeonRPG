using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/Enemy_Anything")]
public class Enemy_Base : ScriptableObject
{
    public string Enemy_Name;                   // 적 이름
    public float Enemy_HealthPoint;             // 적 체력
    public float Enemy_SpeedPoint;              // 적 이동속도

    public float Enemy_AttackPoint;             // 공격력
    public float Enemy_AttackSpeed;             // 공격 연사속도
    public string Enemy_AttackType;             // 공격 속성    (아직 미구현)

    public string Enemy_Infomation;       // 정보
}