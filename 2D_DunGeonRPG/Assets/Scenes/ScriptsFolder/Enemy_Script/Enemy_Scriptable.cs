using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/Enemy_Anything")]
public class Enemy_Base : ScriptableObject
{
    public string Enemy_Name;                   // �� �̸�
    public float Enemy_HealthPoint;             // �� ü��
    public float Enemy_SpeedPoint;              // �� �̵��ӵ�

    public float Enemy_AttackPoint;             // ���ݷ�
    public float Enemy_AttackSpeed;             // ���� ����ӵ�
    public string Enemy_AttackType;             // ���� �Ӽ�    (���� �̱���)

    public string Enemy_Infomation;       // ����
}