using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static float CharacterHP = 3f;
    [SerializeField] private Camera cam;
    [SerializeField] private float CharacterSpeed;
    [SerializeField] private GameObject monsterPrefab;
    private CharacterController characterController;

    private float moveX;
    private float moveY;
    private float moveZ;
    [SerializeField] private float RotateSpeed;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        if(CharacterHP > 0)
        {
            Charactermove();
            CharacterRotate();
        }
        if(CharacterHP > 0 && moveX == 0 && moveZ == 0 && Time.time >= 5f)
        {
            Instantiate(monsterPrefab);
        }
    }
    private void Charactermove()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.forward * moveZ + transform.right * moveX;
        characterController.Move(move * CharacterSpeed * Time.deltaTime);
    }
    private void CharacterRotate()
    {
        moveY = Input.GetKey(KeyCode.Q) ? -1f : Input.GetKey(KeyCode.E) ? 1f : 0f;
        transform.Rotate(0, moveY * Time.deltaTime * RotateSpeed, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Monster"))
        {
            CharacterHP = -1f;
        }
    }
}