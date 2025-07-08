using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalController : MonoBehaviour
{
    private GameObject Character;
    private Image CurrentImage;
    private bool UsedColor;

    private void Start()
    {
        UsedColor = true;
        Character = GameObject.FindGameObjectWithTag("Character");

        if (gameObject.name == "CatPrefab(Clone)")
        {
            CurrentImage = GameObject.Find("Cat_Icon").GetComponent<Image>();
        }
        else if (gameObject.name == "DuckPrefab(Clone)")
        {
            CurrentImage = GameObject.Find("Duck_Icon").GetComponent<Image>();
        }
        else if (gameObject.name == "PenguinPrefab(Clone)")
        {
            CurrentImage = GameObject.Find("Penguin_Icon").GetComponent<Image>();
        }
        else if (gameObject.name == "SheepPrefab(Clone)")
        {
            CurrentImage = GameObject.Find("Sheep_Icon").GetComponent<Image>();
        }
    }
    private void Update()
    {
        if(PlayerMovement.CharacterHP > 0)
        {
            Vector3 LookVec = new Vector3(Character.transform.position.x, Character.transform.position.y + 1f, Character.transform.position.z);
            transform.LookAt(LookVec);
        }
        if (CurrentImage != null && UsedColor)
        {
            UsedColor = false;
            CurrentImage.color = new Color32(255, 255, 255, 20);                        // 시작하면 Color 지정
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Character"))
        {
            if(CurrentImage != null)
            {
                CurrentImage.color = new Color32(255, 255, 255, 255);
            }
            PlayerMovement.AnimalPoint += 1;
            Destroy(gameObject);
        }
    }
}
