using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public static InputSystem Instance { get; private set; }
    public Vector2 Move => move;
    private Vector2 move;

    public static event Action NextScene;
    public static event Action JumpScene;
    public static event Action FixedScene;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
    }
    private void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.P))
        {
            NextScene?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            JumpScene?.Invoke();
        }
    }
    private void FixedUpdate()
    {
    }
    private void Movement()
    {
        float InputX = Input.GetAxis("Horizontal");
        float InputY = Input.GetAxis("Vertical");
        move = new Vector2(InputX, InputY);
    }
}
