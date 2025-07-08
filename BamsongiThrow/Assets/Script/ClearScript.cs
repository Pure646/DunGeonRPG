using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearScrip : MonoBehaviour
{
    [SerializeField] private Text CurrentTime;
    [SerializeField] private Button Replay_Btn;
    private void Start()
    {
        Replay_Btn.onClick.AddListener(() => ReplayGame());
        CurrentTime.text = $"{PointGenerator.hour}.{PointGenerator.per.ToString("D2")}.{PointGenerator.sec.ToString("D2")}";
    }
    private void ReplayGame()
    {
        PlayerMovement.RoundStage = 0;
        SceneManager.LoadScene("AnimalScene");
    }
}
