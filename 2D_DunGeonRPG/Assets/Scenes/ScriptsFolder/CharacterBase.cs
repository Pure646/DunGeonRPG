using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterBase : MonoBehaviour
{
    private Animator anime;
    private Rigidbody2D rigid;
    private bool OnGround;
    private int moreJump;
    private bool OnAir;

    public int AddJump;
    public float characterSpeed;
    public float JumpingPower;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
    }
    private void Start()
    {
        JumpingPower = 6f;
        characterSpeed = 0.5f;
        AddJump = 1;
        moreJump = AddJump;
    }
    private void OnEnable()
    {
        InputSystem.OnJump += Jumping;
        InputSystem.StopMove += StopMovement;
        InputSystem.WalkMove += CharacterMovement;
    }
    private void OnDisable()
    {
        InputSystem.OnJump -= Jumping;
        InputSystem.StopMove -= StopMovement;
        InputSystem.WalkMove -= CharacterMovement;
    }
    private void Update()
    {
        CharacterAnime();
        CharacteraRotation();
        Rayer();
    }
    private void FixedUpdate()
    {

    }
    //public float rayLength = 1f;
    private void Rayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.8f);
        
        if (hit.collider != null)
        {
            OnAir = false;
            Debug.DrawRay((Vector2)transform.position, Vector2.down * 0.8f, Color.red);
        }
        else
        {
            OnAir = true;
        }

    }
    private void StopMovement()
    {
        rigid.velocity = new Vector2(0f, rigid.velocity.y);
    }

    private void Jumping()
    {
        if(moreJump > 0)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, 0f);
            rigid.AddForce(Vector2.up * JumpingPower, ForceMode2D.Impulse);
            moreJump -= 1;
        }
    }

    private void CharacterMovement()
    {
        rigid.AddForce(InputSystem.Instance.Move * characterSpeed, ForceMode2D.Impulse);
    }
    private void CharacteraRotation()
    {
        if(InputSystem.Instance.Move.x < 0f)
        {
            transform.rotation = Quaternion.Euler(0, -180f, 0);
        }
        else if(InputSystem.Instance.Move.x > 0f)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    private void CharacterAnime()
    {
        anime.SetFloat("Magnitude", InputSystem.Instance.Move.magnitude);
        anime.SetBool("Air", OnAir);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            OnGround = true;
            moreJump = AddJump;
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
