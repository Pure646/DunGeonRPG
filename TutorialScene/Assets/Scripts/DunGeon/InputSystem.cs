using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public static InputSystem Instance { get; private set; }
    public event Action<Vector2> CharacterMove;
    public event Action CharacterAttack;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        Vector2 moveVector = Vector2.zero;
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            moveVector = Vector2.left;
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            moveVector = Vector2.right;
        }
        if (moveVector != null)
        {
            CharacterMove?.Invoke(moveVector);
        }
        if(Input.GetKeyDown(KeyCode.Z))
        {
            CharacterAttack?.Invoke();
        }
    }
    
}
