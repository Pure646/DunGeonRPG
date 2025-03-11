using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public static InputSystem Instance { get; private set; }
    public Vector2 Move => move;
    private Vector2 move;
    public Vector3 Look => look;
    private Vector3 look;

    public event Action OnJump;
    public event Action KeepRun;
    public event Action StopRun;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    private void Update()
    {
        Inputsystem();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            OnJump?.Invoke();
        }
        if(Input.GetKey(KeyCode.LeftShift))
        {
            KeepRun?.Invoke();
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            StopRun?.Invoke();
        }
    }

    private void Inputsystem()
    {
        float InputX = Input.GetAxis("Horizontal");
        float InputY = Input.GetAxis("Vertical");
        move = new Vector2(InputX, InputY);

        float LookX = Input.GetAxis("Mouse X");
        float LookY = Input.GetAxis("Mouse Y");
        look = new Vector2(LookX, LookY);
    }

}
