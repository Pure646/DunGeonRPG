using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DunGeonRPG;

public class HealthManaPoint : MonoBehaviour
{
    [SerializeField] private Image PointBar;
    [SerializeField] private Image LostBar;
    private float Current_Health;       // �ش� ü�� = (Max)100
    private float Current_Mana;         // �ش� ���� = (Max)100
    private float Changed_Health;       // �ٲ� ü��
    private float Changed_Mana;         // �ٲ� ����

    [SerializeField] private int AddHealth;              // �߰� ü��       // �ʱⰪ : 1 (��Ʈ �Ѱ�)
    [SerializeField] private int AddMana;                // �߰� ����       // �ʱⰪ : 1 (��Ʈ �Ѱ�)

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
    private void InGameManaBar()            // ���� ü�� Ȥ�� ������ �Ҹ��ϸ� fillamount ���� ä��� ����
    {
        if (PointBar == null)
        { return; }
        PointBar.fillAmount = Changed_Mana / 100;
        Current_Mana = Changed_Mana;
    }
}
