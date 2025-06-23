using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextManager : MonoBehaviour
{
    [SerializeField] private List<Text> texts;

    public void UpdateAllTexts(string message)
    {
        foreach (var text in texts)
        {
            if (text != null)
                text.text = message;
        }
    }
}
