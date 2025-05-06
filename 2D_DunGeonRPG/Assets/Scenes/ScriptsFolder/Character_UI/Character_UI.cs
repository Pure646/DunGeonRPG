using System.Collections;
using System.Collections.Generic;
using DunGeonRPG;
using UnityEngine;
using UnityEngine.UI;

public class Character_UI : MonoBehaviour
{
    public static Character_UI Instance { get; private set; }

    private GameObject character;
    private CharacterBase characterBase;

    [SerializeField] private GameObject HealthPointBase;
    [SerializeField] private GameObject ManaPointBase;

    private List<GameObject> HealthPoint = new List<GameObject>();
    private List<GameObject> ManaPoint = new List<GameObject>();
    private List<RectTransform> Rect_HP = new List<RectTransform>();
    private List<RectTransform> Rect_MP = new List<RectTransform>();
    private List<Image> Health_Image = new List<Image>();
    private List<Image> Mana_Image = new List<Image>();
    private List<Image> LostHealth_Image = new List<Image>();
    private List<Image> LostMana_Image = new List<Image>();

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        character = GameObject.FindGameObjectWithTag("Character");
        if(character != null)
        {
            characterBase = character.GetComponent<CharacterBase>();
        }
    }
    private void Update()
    {
        HealthPointClone();
        ManaPointClone();
        CurrentHealth_Image();
        CurrentMana_Image();
        Reset_HpMp();
    }
    private void Reset_HpMp()
    {
        if(characterBase.NowHealth < characterBase.NowCurrentHealth)
        {
            characterBase.NowCurrentHealth = characterBase.AddHealth;           //오버 금지
        }
    }
    private void CurrentHealth_Image()
    {
        if(characterBase.NowCurrentHealth != characterBase.ChangeCurrentHealth)
        {
            for (int i = 0; i < Health_Image.Count; i++)
            {
                float FillHealth = Mathf.Clamp01(characterBase.NowCurrentHealth - i);
                Health_Image[i].fillAmount = FillHealth;
                LostHealth_Image[i].fillAmount = 1 - FillHealth;
            }
            if(Health_Image.Count > 0)
            {
                characterBase.ChangeCurrentHealth = characterBase.NowCurrentHealth;
            }
        }
    }
    private void CurrentMana_Image()
    {
        if(characterBase.NowCurrentMana != characterBase.ChangeCurrentMana)
        {
            for(int i = 0; i < Mana_Image.Count; i++)
            {
                float FillMana = Mathf.Clamp01(characterBase.NowCurrentMana - i);
                Mana_Image[i].fillAmount = FillMana;
                LostMana_Image[i].fillAmount = 1 - FillMana;
            }
            if(Mana_Image.Count > 0)
            {
                characterBase.ChangeCurrentMana = characterBase.NowCurrentMana;
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

                        Image HealthChild = HealthPoint[i].transform.Find("Hp_Bar").GetComponent<Image>();
                        Health_Image.Add(HealthChild);
                        Image LostHealthChild = HealthPoint[i].transform.Find("Hp_BarLost").GetComponent<Image>();
                        LostHealth_Image.Add(LostHealthChild);

                        Health_Image[i].fillAmount = 0;
                        LostHealth_Image[i].fillAmount = 1;
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
                    if (i < Health_Image.Count)
                    {
                        Health_Image.RemoveAt(i);
                    }
                    if (i < LostHealth_Image.Count)
                    {
                        LostHealth_Image.RemoveAt(i);
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
            Health_Image.Clear();
            LostHealth_Image.Clear();
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

                        Image ManaChild = ManaPoint[i].transform.Find("Mp_Bar").GetComponent<Image>();
                        Mana_Image.Add(ManaChild);
                        Image LostManaChild = ManaPoint[i].transform.Find("Mp_BarLost").GetComponent<Image>();
                        LostMana_Image.Add(LostManaChild);

                        Mana_Image[i].fillAmount = 0;
                        LostMana_Image[i].fillAmount = 1;
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
                    if (i < Mana_Image.Count) 
                    {
                        Mana_Image.RemoveAt(i);
                    }
                    if (i < LostMana_Image.Count) 
                    {
                        LostMana_Image.RemoveAt(i);
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
            Mana_Image.Clear();
            LostMana_Image.Clear();
            characterBase.NowMana = characterBase.AddMana;
        }
    }
}
