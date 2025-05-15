using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private enum EnemyName
    {
        None = 0,
        MiniSlime = 1,
        Goblin = 2,
    }

    [SerializeField] private int EnemyNumber;
    [SerializeField] private GameObject MiniSlime;
    [SerializeField] private Enemy_Base MiniSlimeInfo;

    private List<GameObject> enemyGameObject;
    private List<Enemy_Base> enemyInfo;
    private void Awake()
    {
    }
    private void Start()
    {
        enemyGameObject = new List<GameObject>();
        enemyInfo = new List<Enemy_Base>();

        enemyGameObject.Add(Instantiate(MiniSlime));
        enemyGameObject[0].transform.SetParent(gameObject.transform);
        enemyInfo.Add(MiniSlimeInfo);
        
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            Monster();
        }
    }
    private void Monster()
    {
        if (enemyInfo[0].Enemy_Name == enemyGameObject[0].tag)
        {
            Debug.Log($"이름 : {enemyInfo[0].Enemy_Name} , 설명 : {enemyInfo[0].Information}");
        }
    }
}