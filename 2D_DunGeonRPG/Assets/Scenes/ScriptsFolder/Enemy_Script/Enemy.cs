using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Enemyes
{
    public string Enemy_Name;                   // 적 이름
    public float Enemy_HealthPoint;             // 적 체력
    public float Enemy_SpeedPoint;              // 적 이동속도

    public float Enemy_AttackPoint;             // 공격력
    public float Enemy_AttackSpeed;             // 공격 연사속도
    public string Enemy_AttackType;             // 공격 속성    (아직 미구현)

    public string Enemy_Infomation;

    //public void Checking(string name, string info)
    //{
    //    Debug.Log($"이름 : {name} , 정보 : {info}");
    //}
    //public void ToolChecking()
    //{
    //    Debug.Log($"이름 : {Enemy_Name} , 정보 : {Enemy_Infomation}");
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
        //Es = new Enemyes();           // 매개변수로 객체 참조를 넘길 때, 해당 참조 자체를 바꾸면 호출한 쪽에는 반영되지 않기 때문
        Es.Enemy_Name         = Eb.Enemy_Name;
        Es.Enemy_HealthPoint  = Eb.Enemy_HealthPoint;
        Es.Enemy_SpeedPoint   = Eb.Enemy_SpeedPoint;
        Es.Enemy_AttackPoint  = Eb.Enemy_AttackPoint;
        Es.Enemy_AttackSpeed  = Eb.Enemy_AttackSpeed;
        Es.Enemy_AttackType   = Eb.Enemy_AttackType;
        Es.Enemy_Infomation   = Eb.Enemy_Infomation;
    }
}