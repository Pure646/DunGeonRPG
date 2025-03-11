using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{

    [SerializeField] private CharacterController characterController;
    [SerializeField] private UnityEngine.CharacterController controller;

    [SerializeField] private float walkSpeed = 1f;
    [SerializeField] private float runSpeed = 2f;

    private float finalSpeed = 1f;
    //private float gravity = -9.81f;

    private bool OnGround;
    public bool OnRun;
    public bool OnJump;


    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        controller = GetComponent<UnityEngine.CharacterController>();
    }
    private void Update()
    {
        Gravity();
        Movement();
    }
    private void FixedUpdate()
    {
    }
    private void Movement()
    {
        finalSpeed = OnRun ? runSpeed : walkSpeed;
        float InputX = InputSystem.Instance.Move.x;
        float InputY = InputSystem.Instance.Move.y;
        Vector3 moveVector = new Vector3(InputX, 0, InputY) * Time.deltaTime * 5f;

        controller.Move(moveVector * finalSpeed);
        
    }
    private void Gravity()
    {
        if(OnGround)
        {

        }
    }
}
