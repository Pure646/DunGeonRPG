using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    private void Update()
    {
        if(Input.anyKeyDown)
        {
            PlayerMovement.RoundStage += 1;
            SceneManager.LoadScene("AnimalScene");
        }
    }
}
