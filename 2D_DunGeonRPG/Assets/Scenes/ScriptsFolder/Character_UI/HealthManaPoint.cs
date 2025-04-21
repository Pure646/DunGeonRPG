using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DunGeonRPG;

public class HealthManaPoint : MonoBehaviour
{
    [SerializeField] private Image PointBar;
    [SerializeField] private Image LostBar;
    private float Current_Health;       // 해당 체력 = (Max)100
    private float Current_Mana;         // 해당 마나 = (Max)100
    private float Changed_Health;       // 바뀐 체력
    private float Changed_Mana;         // 바뀐 마나

    [SerializeField] private int AddHealth;              // 추가 체력       // 초기값 : 1 (하트 한개)
    [SerializeField] private int AddMana;                // 추가 마나       // 초기값 : 1 (하트 한개)

    private GameObject My_Character;
    private CharacterBase characterBase;

    private void Awake()
    {
        if (PointBar != null)
        {
            PointBar = GetComponent<Image>();
        }
        if(LostBar != null)
        {
            LostBar = GetComponent <Image>();
        }
        
    }
    private void Start()
    {
        My_Character = GameObject.FindGameObjectWithTag("Character");
        if (My_Character != null)
        {
            characterBase = My_Character.GetComponent<CharacterBase>();
        }
    }
    private void Update()
    {
        if (characterBase != null)
        {
            if(Mathf.Approximately(Changed_Health, characterBase.CurrentHealth) == false)
            {
                ChangeHealth();
            }
        }
        if (Mathf.Approximately(Current_Health, Changed_Health) == false)
        {
            InGameHealthBar();
            InGameLostHealth();
        }
        if (Mathf.Approximately(Current_Mana, Changed_Mana) == false)
        {
            InGameManaBar();
            InGameLostMana();
        }
    }
    private void ChangeHealth()
    {
        Changed_Health = characterBase.CurrentHealth;
    }
    private void InGameLostHealth()
    {
        if(LostBar == null)
        { return; }
        LostBar.fillAmount = 1 - Changed_Health / 100;
        Current_Health = Changed_Health;
    }
    private void InGameLostMana()
    {
        if (LostBar == null)
        { return; }
        LostBar.fillAmount = 1 - Changed_Mana / 100;
        Current_Mana = Changed_Mana;
    }
    private void InGameHealthBar()
    {
        if (PointBar == null)
        { return; }
        PointBar.fillAmount = Changed_Health / 100;
        Current_Health = Changed_Health;
    }
    private void InGameManaBar()            // 만약 체력 혹은 마나가 소모하면 fillamount 값을 채우는 형식
    {
        if (PointBar == null)
        { return; }
        PointBar.fillAmount = Changed_Mana / 100;
        Current_Mana = Changed_Mana;
    }
}
