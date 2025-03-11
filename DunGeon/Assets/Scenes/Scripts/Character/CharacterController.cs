using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private CharacterBase characterBase;
    private void Awake()
    {
        characterBase = GetComponent<CharacterBase>();
    }
    private void Start()
    {
        
    }
    private void OnEnable()
    {
        if(InputSystem.Instance != null)
        {
            InputSystem.Instance.OnJump += CharacterJump;
            InputSystem.Instance.KeepRun += KeepRunning;
            InputSystem.Instance.StopRun += StopRunning;
        }
    }
    public void StopRunning()
    {
        if(characterBase.OnRun == true)
        {
            characterBase.OnRun = false;
        }
    }
    public void KeepRunning()
    {
        if (characterBase.OnRun == false)
        {
            characterBase.OnRun = true;
        }
    }

    public void CharacterJump()
    {
        if(characterBase.OnJump == false)
        {
            characterBase.OnJump = true;
        }
    }
    
}
