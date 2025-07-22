using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator animator;
    private float CharacterSpeed = 2f;               // 기본 이동속도
    private float CharacterMaxSpeed = 10f;           // 최대맥스 스피드

    private bool OnRolls = false;                           // 구르기
    private void Awake()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
    }
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        animator.SetFloat("Velocity", rig.velocity.magnitude);
        animator.SetBool("OnRollsMostion", OnRolls);
        if(CharacterMaxSpeed < CharacterSpeed)
        {
            CharacterSpeed = CharacterMaxSpeed;
        }
    }
    private void OnEnable()
    {
        if (InputSystem.Instance != null)
        {
            InputSystem.Instance.CharacterMove += CharacterMove;
            InputSystem.Instance.CharacterStop += CharacterStop;
            InputSystem.Instance.CharacterRolls += CharacterRolling;
        }
    }
    private void OnDisable()
    {
        if(InputSystem.Instance != null)
        {
            InputSystem.Instance.CharacterMove -= CharacterMove;
            InputSystem.Instance.CharacterStop -= CharacterStop;
            InputSystem.Instance.CharacterRolls -= CharacterRolling;
        }
    }
    private void CharacterMove(Vector2 Vec)
    {
        if (rig.velocity.magnitude > CharacterSpeed + 2f)
        {
            rig.velocity = rig.velocity.normalized * (CharacterSpeed + 2f);
        }
        else
        {
            rig.AddForce(Vec * Time.deltaTime * 10f * CharacterSpeed, ForceMode2D.Impulse);
        }
        if(Vec.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    private void CharacterStop(Vector2 zero)
    {
        rig.velocity = zero;        // 바로 멈춤
    }
    private void CharacterRolling()
    {
        OnRolls = true;
    }
    private void CharacterRollingEnd()
    {
        if(OnRolls == true)
        {
            OnRolls = false;
        }
    }

}
