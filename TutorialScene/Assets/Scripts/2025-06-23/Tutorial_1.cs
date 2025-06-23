using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_1 : MonoBehaviour
{
    [SerializeField] private Button tutorialButton;
    [SerializeField] private UITextManager uiTextManager;

    private int clickCount = 0;

    private void Start()
    {
        if (tutorialButton != null)
            tutorialButton.onClick.AddListener(OnButtonClick);

        uiTextManager.UpdateAllTexts($"Click : {clickCount}");
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            IncrementCount();
        }
    }

    private void OnButtonClick()
    {
        IncrementCount();
    }

    private void IncrementCount()
    {
        clickCount++;
        uiTextManager.UpdateAllTexts($"Click : {clickCount}");
    }
}