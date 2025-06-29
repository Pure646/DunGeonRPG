using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D rigd;
    private Animator animator;
    private bool ChangeMagnitude;
    private float CharacterSpeed;
    private float CharacterMaxSpeed;
    private int CharacterAttackCombo;
    private int AttackCount;
    private AnimatorStateInfo StateInfo;
    private void Start()
    {
        rigd = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        CharacterSpeed = 20;
        CharacterMaxSpeed = 7;
    }
    private void OnEnable()
    {
        if(InputSystem.Instance != null)
        {
            InputSystem.Instance.CharacterMove += moveAction;
            InputSystem.Instance.CharacterAttack += AttackAction;
        }
    }
    private void OnDisable()
    {
        if (InputSystem.Instance != null)
        {
            InputSystem.Instance.CharacterMove -= moveAction;
            InputSystem.Instance.CharacterAttack -= AttackAction;
        }
    }
    private void Update()
    {
        if(InputSystem.Instance == null)
        {
            Debug.Log("Hi");
        }
        animator.SetFloat("Velocity", Mathf.Abs(rigd.velocity.x));
        animator.SetInteger("AttackCombo", CharacterAttackCombo);
        if(CharacterAttackCombo != 0)                                   // 공격시 카운팅
        {
            AttackActionEnd();
            if(CharacterSpeed != 10)
            {
                CharacterSpeed = 10;
                CharacterMaxSpeed = 2.5f;
            }
        }
        else if(CharacterSpeed != 20)
        {
            CharacterSpeed = 20;
            CharacterMaxSpeed = 7f;
        }
    }
    private void moveAction(Vector2 moveVector)
    {
        if (moveVector == Vector2.zero)
        {
            rigd.velocity = Vector2.zero;
            return;
        }
        bool isMovingRight = moveVector.x > 0;
        if (ChangeMagnitude != isMovingRight)
        {
            ChangeMagnitude = isMovingRight;
            transform.rotation = Quaternion.Euler(0, isMovingRight ? 0 : 180, 0);
            rigd.velocity = Vector2.zero;
        }

        if (Mathf.Abs(rigd.velocity.x) < CharacterMaxSpeed)                 // 움직이는 힘
        {
            rigd.AddForce(moveVector * CharacterSpeed * Time.deltaTime, ForceMode2D.Impulse);
        }
    }

    private void AttackAction()                         // Action 시작 + Count++
    {
        if(CharacterAttackCombo < 3)
        {
            CharacterAttackCombo++;
        }
    }
    private void AttackActionEnd()                      // Action 끝
    {
        StateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (StateInfo.IsName($"AttackCombo_{AttackCount + 1}") && StateInfo.normalizedTime > 0.95f) 
        {
            AttackCount++;
        }
        if(AttackCount >= CharacterAttackCombo)
        {
            CharacterAttackCombo = 0;
            AttackCount = 0;
        }
    }
}
