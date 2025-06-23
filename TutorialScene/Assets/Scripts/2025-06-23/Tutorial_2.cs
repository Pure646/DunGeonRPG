using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_2 : MonoBehaviour
{
    [SerializeField] private List<Text> textsArray = new List<Text>();
    [SerializeField] private UIElement element;
    [SerializeField] private string Name;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            UpdateText();
        }
        if(Input.GetKeyDown(KeyCode.J))
        {
            foreach (var Tx in textsArray)
            {
                if (Tx != null)
                {
                    element.Information(Name, Tx);
                }
            }
        }
    }
    private void UpdateText()
    {
        foreach (var Tx in textsArray)
        {
            if (Tx != null)
            {
                Tx.text = "Upgrade !!";
            }
        }
    }


}
