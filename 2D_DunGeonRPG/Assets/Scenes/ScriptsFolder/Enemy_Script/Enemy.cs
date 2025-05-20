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

}
public class Enemy : MonoBehaviour
{
    public static Enemy Instance { get; private set; }
    public Enemy_Base[] Enemyes_Info;
    private Enemyes[] Enemyes_Set;

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void Start()
    {
        Enemyes_Set = new Enemyes[Enemyes_Info.Length];

        Enemy_Information();
    }
    private void Enemy_Information()            // 몬스터 정보 초기화
    {
        for (int i = 0; i < Enemyes_Info.Length; i++)
        {
            Enemyes_Set[i] = new Enemyes();
            Enemyes_Set[i].Enemy_Name = Enemyes_Info[i].Enemy_Name;
            Enemyes_Set[i].Enemy_HealthPoint = Enemyes_Info[i].Enemy_HealthPoint;
            Enemyes_Set[i].Enemy_SpeedPoint = Enemyes_Info[i].Enemy_SpeedPoint;
            Enemyes_Set[i].Enemy_AttackPoint = Enemyes_Info[i].Enemy_AttackPoint;
            Enemyes_Set[i].Enemy_AttackSpeed = Enemyes_Info[i].Enemy_AttackSpeed;
            Enemyes_Set[i].Enemy_AttackType = Enemyes_Info[i].Enemy_AttackType;
            Enemyes_Set[i].Enemy_Infomation = Enemyes_Info[i].Enemy_Infomation;
        }
    }
}