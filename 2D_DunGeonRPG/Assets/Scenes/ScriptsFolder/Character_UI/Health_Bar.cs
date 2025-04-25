using System.Collections;
using System.Collections.Generic;
using DunGeonRPG;
using UnityEngine;
using UnityEngine.UI;

public class Health_Bar : MonoBehaviour
{
    private GameObject character;
    private CharacterBase characterBase;
    public Image Hp_BarLost;
    public Image Hp_Bar;

    private void Awake()
    {
        character = GameObject.FindGameObjectWithTag("Character");
        if(character != null)
        {
            characterBase = character.GetComponent<CharacterBase>();
        }
    }

    private void Update()
    {
        HpBar();
        HpLostBar();
    }
    private void HpBar()
    {
        Hp_Bar.fillAmount = characterBase.CurrentHealth / 100;
    }
    private void HpLostBar()
    {
        Hp_BarLost.fillAmount = 1 - characterBase.CurrentHealth / 100;
    }
}
