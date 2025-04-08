using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNext : MonoBehaviour
{
    public static SceneNext Instance { get; private set; }
    private Scene currentScene;
    private int currentSeed;
    private int fixSeed = -9999;

    public int jumpSeed;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void OnEnable()
    {
        InputSystem.NextScene += Next_Scene;
        InputSystem.JumpScene += Jump_Scene;
    }
    
    private void OnDisable()
    {
        InputSystem.NextScene -= Next_Scene;
        InputSystem.JumpScene -= Jump_Scene;
    }
    private void Update()
    {
        if(fixSeed != currentSeed)          
        {
            currentScene = SceneManager.GetActiveScene();       // Scene이 바뀌면서 바로 호출이 잘 안되어서 Update로 사용
            CurrentSceneCheck();
            fixSeed = currentSeed;
        }
    }
    private void Next_Scene()
    {
        for (int i = -1; i < 100; i++)
        {
            if (currentSeed == i)
            {
                SceneManager.LoadScene($"World {i + 1}");
                fixSeed = currentSeed + 1;
                break;
            }
        }
    }
    private void Jump_Scene()
    {
        if (jumpSeed == -1)
        {
            SceneManager.LoadScene($"StartScene");
            fixSeed = jumpSeed + 1;
        }
        else if (jumpSeed == currentSeed)
        {
            Debug.Log("같은 씬으로 점프 할 수 없습니다.");
        }
        else
        {
            SceneManager.LoadScene($"World {jumpSeed}");
            fixSeed = jumpSeed + 1;
        }
    }
    private void CurrentSceneCheck()
    {
        switch (currentScene.name)
        {
            case "StartScene":
                currentSeed = -1;
                break;
            case "World 0":
                currentSeed = 0;
                break;
            case "World 1":
                currentSeed = 1;
                break;
            case "World 2":
                currentSeed = 2;
                break;
            default:
                Debug.Log("CurrentScene Error");
                break;
        }
    }
}
