using System.Collections;
using System.Collections.Generic;
using DunGeonRPG;
using UnityEngine;
using UnityEngine.UI;

public class Character_UI : MonoBehaviour
{
    private GameObject character;
    private CharacterBase characterBase;

    [SerializeField] private GameObject HealthPointBase;
    [SerializeField] private GameObject ManaPointBase;

    private List<GameObject> HealthPoint = new List<GameObject>();
    private List<GameObject> ManaPoint = new List<GameObject>();
    private List<RectTransform> Rect_HP = new List<RectTransform>();
    private List<RectTransform> Rect_MP = new List<RectTransform>();
    private List<Image> Health_Img = new List<Image>();
    private List<Image> HealthLost_Img = new List<Image>();
    private List<Image> Mana_Img = new List<Image>();
    private List<Image> ManaLost_Img = new List<Image>();

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

    }
    private void Update()
    {
        HealthPointClone();
        ManaPointClone();
    }
    private void Current_Health()
    {
        if (HealthPoint.Count >= 0 && characterBase.NowCurrentHealth != characterBase.ChangeCurrentHealth) 
        {
            for(int i = 0; i < HealthPoint.Count; i++)
            {
                //if (HealthPoint[i])
            }
        }
    }
    private void HealthPointClone()
    {
        if(characterBase.AddHealth != characterBase.NowHealth && characterBase.AddHealth > 0)
        {
            if (characterBase.AddHealth - characterBase.NowHealth > 0)
            {
                for (int i = 0; i < characterBase.AddHealth; i++)
                {
                    if (HealthPoint.Count <= i) 
                    {
                        HealthPoint.Add(Instantiate(HealthPointBase));
                        HealthPoint[i].transform.SetParent(gameObject.transform);
                        HealthPoint[i].SetActive(true);
                        Rect_HP.Add(HealthPoint[i].GetComponent<RectTransform>());
                        Rect_HP[i].anchoredPosition = new Vector2(40 * i, 0);
                        Rect_HP[i].localScale = new Vector2(1, 1);

                        Image Hp_img = HealthPoint[i].transform.Find("Hp_Bar").GetComponent<Image>();
                        Health_Img.Add(Hp_img);
                        Image HpLost_img = HealthPoint[i].transform.Find("Hp_BarLost").GetComponent<Image>();
                        HealthLost_Img.Add(HpLost_img);
                    }
                }
                characterBase.NowHealth = characterBase.AddHealth;
            }
            else if (characterBase.AddHealth - characterBase.NowHealth < 0)
            {
                for (int i = characterBase.NowHealth - 1; i >= characterBase.AddHealth; i--)
                {
                    if (i < HealthPoint.Count) 
                    {
                        Destroy(HealthPoint[i]);
                        HealthPoint.RemoveAt(i);
                    }
                    if (i < Rect_HP.Count) 
                    {
                        Rect_HP.RemoveAt(i);
                    }
                    if (i < Health_Img.Count) 
                    {
                        Health_Img.RemoveAt(i);
                    }
                    if (i < HealthLost_Img.Count) 
                    {
                        HealthLost_Img.RemoveAt(i);
                    }
                }
                characterBase.NowHealth = characterBase.AddHealth;
            }
        }
        if (characterBase.AddHealth == 0 && HealthPoint.Count > 0)
        {
            for (int i = characterBase.NowHealth - 1; i >= characterBase.AddHealth; i--)
            {
                Destroy(HealthPoint[i]);
            }
            HealthPoint.Clear();
            Rect_HP.Clear();
            Health_Img.Clear();
            HealthLost_Img.Clear();
            characterBase.NowHealth = characterBase.AddHealth;
        }
    }
    private void ManaPointClone()
    {
        if (characterBase.AddMana != characterBase.NowMana && characterBase.AddMana > 0)
        {
            if (characterBase.AddMana - characterBase.NowMana > 0)
            {
                for (int i = 0; i < characterBase.AddMana; i++)
                {
                    if (ManaPoint.Count <= i)
                    {
                        ManaPoint.Add(Instantiate(ManaPointBase));
                        ManaPoint[i].transform.SetParent(gameObject.transform);
                        ManaPoint[i].SetActive(true);
                        Rect_MP.Add(ManaPoint[i].GetComponent<RectTransform>());
                        Rect_MP[i].anchoredPosition = new Vector2(35 * i, 0);
                        Rect_MP[i].localScale = new Vector2(1, 1);

                        Image Mp_img = ManaPoint[i].transform.Find("Mp_Bar").GetComponent<Image>();
                        Mana_Img.Add(Mp_img);
                        Image MpLost_img = ManaPoint[i].transform.Find("Mp_BarLost").GetComponent<Image>();
                        ManaLost_Img.Add(MpLost_img);
                    }
                }
                characterBase.NowMana = characterBase.AddMana;
            }
            else if (characterBase.AddMana - characterBase.NowMana < 0)
            {
                for (int i = characterBase.NowMana - 1; i >= characterBase.AddMana; i--)
                {
                    if (i < ManaPoint.Count)
                    {
                        Destroy(ManaPoint[i]);
                        ManaPoint.RemoveAt(i);
                    }
                    if (i < Rect_MP.Count)
                    {
                        Rect_MP.RemoveAt(i);
                    }
                    if (i < Mana_Img.Count) 
                    {
                        Mana_Img.RemoveAt(i);
                    }
                    if (i < ManaLost_Img.Count) 
                    {
                        ManaLost_Img.RemoveAt(i);
                    }
                }
                characterBase.NowMana = characterBase.AddMana;
            }
        }
        if (characterBase.AddMana == 0 && ManaPoint.Count > 0)
        {
            for (int i = characterBase.NowMana - 1; i >= characterBase.AddMana; i--)
            {
                Destroy(ManaPoint[i]);
            }
            ManaPoint.Clear();
            Rect_MP.Clear();
            Mana_Img.Clear();
            ManaLost_Img.Clear();
            characterBase.NowMana = characterBase.AddMana;
        }
    }
}
