using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public static InputSystem Instance { get; set;}

    public event Action<Vector2> CharacterMove;
    public event Action<Vector2> CharacterStop;

    public event Action CharacterRolls;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            CharacterMove?.Invoke(Vector2.left);
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            CharacterStop?.Invoke(Vector2.zero);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            CharacterMove?.Invoke(Vector2.right);
        }
        if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            CharacterStop?.Invoke(Vector2.zero);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            // มกวม
        }
        if(Input.GetKey(KeyCode.LeftControl))
        {
            CharacterRolls?.Invoke();
        }
    }
}
