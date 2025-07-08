using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PointGenerator : MonoBehaviour
{
    [SerializeField] private Text Round_Txt;
    [SerializeField] private Image[] Heart_Img;
    [SerializeField] private Text Time_Txt;
    [SerializeField] private Text Gold_Txt;
    [SerializeField] private Image GameOver;
    // -- 현재 라운드
    private int nowRound;
    // --- 체력
    private float currentHP;
    // --- 시간
    private float settime;          // 지나가는 시간;
    public static int sec;                // 초
    public static int per;                // 분
    public static int hour;               // 시
    // --- 현재 골드
    private int GoldPoint;
    void Start()
    {
        nowRound = 0;
        currentHP = PlayerMovement.CharacterHP;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMovement.RoundStage != nowRound)
        {
            Round_Txt.text = $"Round : {PlayerMovement.RoundStage}";
            nowRound = PlayerMovement.RoundStage;
        }
        if(PlayerMovement.RoundStage == 0)
        {
            nowRound = 0;
        }
        if(PlayerMovement.CharacterHP != currentHP)
        {
            float HP = PlayerMovement.CharacterHP;          // 1.5
            for(int i = 0; i < Heart_Img.Length; i ++)
            {
                Heart_Img[i].fillAmount = Mathf.Clamp(HP, 0, 1);
                HP--;
            }
            currentHP = PlayerMovement.CharacterHP;
        }
        if(PlayerMovement.CharacterHP > 0)
        {
            SettingTime();
        }
        if(PlayerMovement.GoldPoint != GoldPoint)
        {
            Gold_Txt.text = $"Gold : {PlayerMovement.GoldPoint}";
            GoldPoint = PlayerMovement.GoldPoint;
        }
        if(PlayerMovement.CharacterHP <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
        if (PlayerMovement.RoundStage == 11)
        {
            SceneManager.LoadScene("GameClearScene");
        }
    }
    private void SettingTime()
    {
        settime += Time.deltaTime;
        if(settime >= 1)
        {
            settime -= 1;
            sec += 1;
        }
        if(sec >= 60)
        {
            per += 1;
            sec -= 60;
        }
        if(per >= 60)
        {
            per -= 60;
            hour += 1;
        }
        Time_Txt.text = $"{hour}.{per.ToString("D2")}.{sec.ToString("D2")}";
    }
}
