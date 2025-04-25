using System.Collections;
using System.Collections.Generic;
using DunGeonRPG;
using UnityEngine;
using UnityEngine.UI;

public class Character_UI : MonoBehaviour
{
    private GameObject character;
    private CharacterBase characterBase;
    private RectTransform[] Rect_HP;
    private RectTransform[] Rect_MP;

    [SerializeField] private GameObject HealthPointBase;
    [SerializeField] private GameObject ManaPointBase;
    private GameObject[] HealthPoint;
    private GameObject[] ManaPoint;

    private void Awake()
    {
        character = GameObject.FindGameObjectWithTag("Character");
        if(character != null)
        {
            characterBase = character.GetComponent<CharacterBase>();
        }
    }
    private void Start()
    {
        Rect_HP = new RectTransform[100];
        Rect_MP = new RectTransform[100];
        HealthPoint = new GameObject[100];
        ManaPoint = new GameObject[100];

        HealthPoint[0] = HealthPointBase;
        ManaPoint[0] = ManaPointBase;
        Rect_HP[0] = HealthPoint[0].GetComponent<RectTransform>();
    }
    private void Update()
    {
        HealthPointClone();
        ManaPointClone();
    }
    
    private void HealthPointClone()
    {
        if(characterBase.AddHealth != characterBase.NowHealth)
        {
            if (characterBase.AddHealth - characterBase.NowHealth > 0)
            {
                for (int i = 0; i < characterBase.AddHealth; i++)
                {
                    if (HealthPoint[i] == null)
                    {
                        HealthPoint[i] = Instantiate(HealthPointBase, Vector2.zero, Quaternion.identity, this.transform);
                        Rect_HP[i] = HealthPoint[i].GetComponent<RectTransform>();
                        Rect_HP[i].anchoredPosition = new Vector2(40 * i , 0);
                    }
                }
            }
            else if (characterBase.AddHealth - characterBase.NowHealth < 0)
            {
                for (int i = characterBase.NowHealth; i > characterBase.AddHealth; i--)
                {
                    Destroy(HealthPoint[i]);
                    HealthPoint[i] = null;
                }
            }
            characterBase.NowHealth = characterBase.AddHealth;
        }
    }
    private void ManaPointClone()
    {
        if (characterBase.AddMana != characterBase.NowMana)
        {
            if (characterBase.AddMana - characterBase.NowMana > 0)
            {
                for (int i = 0; i < characterBase.AddMana; i++)
                {
                    if (ManaPoint[i] == null)
                    {
                        ManaPoint[i] = Instantiate(ManaPointBase, Vector2.zero, Quaternion.identity, this.transform);
                        Rect_MP[i] = ManaPoint[i].GetComponent<RectTransform>();
                        Rect_MP[i].anchoredPosition = new Vector2(35 * i, 0);
                    }
                }
            }
            else if (characterBase.AddMana - characterBase.NowMana < 0)
            {
                for (int i = characterBase.NowMana; i > characterBase.AddMana; i--)
                {
                    Destroy(ManaPoint[i]);
                    ManaPoint[i] = null;
                }
            }
            characterBase.NowMana = characterBase.AddMana;
        }
    }
}
