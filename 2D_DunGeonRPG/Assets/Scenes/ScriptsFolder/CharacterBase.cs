using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    private Animator anime;
    private Rigidbody2D rigid;
    private bool OnGround;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        InputSystem.OnJump += Jumping;
        InputSystem.StopMove += StopMovement;
    }
    private void OnDisable()
    {
        InputSystem.OnJump -= Jumping;
        InputSystem.StopMove -= StopMovement;
    }
    private void Update()
    {
        TransRotation();
        CharacterAnime();
    }
    private void FixedUpdate()
    {
        rigid.AddForce(InputSystem.Instance.Move, ForceMode2D.Impulse);
    }
    private void StopMovement()
    {
        rigid.velocity = new Vector2(rigid.velocity.normalized.x, rigid.velocity.y);
    }
    public float JumpingPower;
    private void Jumping()
    {
        rigid.AddForce(Vector2.up * JumpingPower,ForceMode2D.Impulse);
    }
    private void CharacterAnime()
    {
        anime.SetFloat("Magnitude", InputSystem.Instance.Move.magnitude);
    }
    private void TransRotation()
    {
        if(OnGround)
        {
            if(InputSystem.Instance.Move.x > 0f)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if(InputSystem.Instance.Move.x < 0f)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            OnGround = true;
        }
    }
    private void OnCollisionExis2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            OnGround = false;
        }
    }

}
