using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public static InputSystem Instance { get; private set; }
    public Vector2 Move => move;
    private Vector2 move;

    public static event Action OnJump;
    public static event Action StopMove;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        Movement();
        if(Input.GetButtonUp("Horizontal"))
        {
            StopMove?.Invoke();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            OnJump?.Invoke();
        }
    }
    private void Movement()
    {
        float InputX = Input.GetAxisRaw("Horizontal");
        move = Vector2.right * InputX;

    }
}
