using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/Enemy_Anything")]
public class Enemy_Base : ScriptableObject
{
    public string Enemy_Name;       // �̸�
    public string Enemy_Type;       // �Ӽ�
    public float AttackDamge;       // ���ݷ�
    public float Armor;             // ����
    public float Speed;             // �̵��ӵ�

    public string Information;       // ����
}
