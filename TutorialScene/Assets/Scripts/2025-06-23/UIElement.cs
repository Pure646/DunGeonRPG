using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class UIElement : MonoBehaviour
{
    public void Information(string name, Text tex)
    {
        tex.text = $"Pick : {name}";
    }
}
