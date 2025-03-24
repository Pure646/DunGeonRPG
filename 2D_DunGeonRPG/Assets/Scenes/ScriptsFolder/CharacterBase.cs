using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    private Rigidbody2D rigid;
    public float MaxSpeed;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float InputX = Input.GetAxis("Horizontal");

        rigid.AddForce(Vector2.right * InputX , ForceMode2D.Impulse);

        if(rigid.velocity.x > MaxSpeed )
        {
            rigid.velocity = new Vector2(MaxSpeed, rigid.velocity.y);
        }
        else if(rigid.velocity.x < MaxSpeed*(-1))
        {
            rigid.velocity = new Vector2(MaxSpeed * (-1), rigid.velocity.y);
        }
    }



}
