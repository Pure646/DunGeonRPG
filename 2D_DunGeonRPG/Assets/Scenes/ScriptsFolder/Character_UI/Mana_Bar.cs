using System.Collections;
using System.Collections.Generic;
using DunGeonRPG;
using UnityEngine;
using UnityEngine.UI;

public class Mana_Bar : MonoBehaviour
{
    private GameObject character;
    private CharacterBase characterBase;
    public Image Mp_BarLost;
    public Image Mp_Bar;

    private void Awake()
    {
        character = GameObject.FindGameObjectWithTag("Character");
        if (character != null)
        {
            characterBase = character.GetComponent<CharacterBase>();
        }
    }

    private void Update()
    {
        ManaBar();
        ManaLostBar();
    }
    private void ManaBar()
    {
        Mp_Bar.fillAmount = characterBase.CurrentMana / 100;
    }
    private void ManaLostBar()
    {
        Mp_BarLost.fillAmount = 1 - characterBase.CurrentMana / 100;
    }
}
