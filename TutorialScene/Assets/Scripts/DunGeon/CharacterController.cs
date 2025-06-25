using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D rigd;
    private Animator animator;
    private bool ChangeMagnitude;
    [SerializeField] private float CharacterSpeed;
    [SerializeField] private float CharacterMaxSpeed;
    private int CharacterAttackCombo;
    private void Start()
    {
        rigd = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetFloat("Velocity", Mathf.Abs(rigd.velocity.x));
        animator.SetInteger("AttackCombo", CharacterAttackCombo);
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);      // AnimatorStateInfo �˾ƿ���.
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
    private void moveAction(Vector2 moveVector)
    {
        //if(moveVector.x < 0 && ChangeMagnitude == true)                     // ���� ��ȯ�� �ٷ� ��ȯ
        //{
        //    ChangeMagnitude = false;
        //    transform.rotation = Quaternion.Euler(0, 180, 0);
        //    rigd.velocity = Vector2.zero;
        //}
        //else if(moveVector.x > 0 && ChangeMagnitude == false)               // ���� ��ȯ�� �ٷ� ��ȯ
        //{
        //    ChangeMagnitude = true;
        //    transform.rotation = Quaternion.Euler(0, 0, 0);
        //    rigd.velocity = Vector2.zero;
        //}
        //else if(moveVector == Vector2.zero)                                 // �̵��� ������ ��
        //{
        //    rigd.velocity = Vector2.zero;
        //}
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

        if (Mathf.Abs(rigd.velocity.x) < CharacterMaxSpeed)                 // �����̴� ��
        {
            rigd.AddForce(moveVector * CharacterSpeed * Time.deltaTime, ForceMode2D.Impulse);
        }
    }

    private void AttackAction()
    {

    }
}
