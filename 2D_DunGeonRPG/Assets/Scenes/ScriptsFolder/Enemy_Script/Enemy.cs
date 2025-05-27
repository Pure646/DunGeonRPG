using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Enemyes
{
    public string Enemy_Name;                   // �� �̸�
    public float Enemy_HealthPoint;             // �� ü��
    public float Enemy_SpeedPoint;              // �� �̵��ӵ�

    public float Enemy_AttackPoint;             // ���ݷ�
    public float Enemy_AttackSpeed;             // ���� ����ӵ�
    public string Enemy_AttackType;             // ���� �Ӽ�    (���� �̱���)

    public string Enemy_Infomation;

    //public void Checking(string name, string info)
    //{
    //    Debug.Log($"�̸� : {name} , ���� : {info}");
    //}
    //public void ToolChecking()
    //{
    //    Debug.Log($"�̸� : {Enemy_Name} , ���� : {Enemy_Infomation}");
    //}
}
public class Enemy : MonoBehaviour
{
    public static Enemy Instance { get; private set; }
    public Enemy_Base[] Enemy_Info;
    private Enemyes[] Enemyes_Set;

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        Enemyes_Set = new Enemyes[Enemy_Info.Length];
    }
    public void Start()
    {
        if (Enemy_Info != null)
        {
            for(int i = 0; i < Enemy_Info.Length; i++)
            {
                Enemyes_Set[i] = new Enemyes();
                EnemyInfo(Enemyes_Set[i], Enemy_Info[i]);
            }
        }
    }
    private void EnemyInfo(Enemyes Es, Enemy_Base Eb)
    {
        //Es = new Enemyes();           // �Ű������� ��ü ������ �ѱ� ��, �ش� ���� ��ü�� �ٲٸ� ȣ���� �ʿ��� �ݿ����� �ʱ� ����
        Es.Enemy_Name         = Eb.Enemy_Name;
        Es.Enemy_HealthPoint  = Eb.Enemy_HealthPoint;
        Es.Enemy_SpeedPoint   = Eb.Enemy_SpeedPoint;
        Es.Enemy_AttackPoint  = Eb.Enemy_AttackPoint;
        Es.Enemy_AttackSpeed  = Eb.Enemy_AttackSpeed;
        Es.Enemy_AttackType   = Eb.Enemy_AttackType;
        Es.Enemy_Infomation   = Eb.Enemy_Infomation;
    }
}