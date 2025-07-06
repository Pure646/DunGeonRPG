using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    private GameObject Character;
    private Rigidbody monsterRigid;
    private float MonsterSpeed;
    private int Level = 1;
    private int Point = 0;

    private void Start()
    {
        Character = GameObject.FindGameObjectWithTag("Character");
        monsterRigid = GetComponent<Rigidbody>();
        MonsterSpeed = 0.1f;
    }

    private void Update()
    {
        if(Point > 100 && Level == 1)
        {
            Level = 2;
        }

        if (transform.position.y < -5f)
        {
            int Randomposition = Random.Range(0, 3);
        }
    }
    private void FixedUpdate()
    {
        if(PlayerMovement.CharacterHP > 0)
        {
            LevelSpeed();
            MonsterMove();
            MonsterRotate();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void MonsterMove()
    {
        Vector3 targetV = (Character.transform.position - transform.position).normalized;
        transform.Translate(targetV * MonsterSpeed, Space.World);
    }
    private void MonsterRotate()
    {
        Vector3 target = new Vector3(Character.transform.position.x, 0, Character.transform.position.z);
        transform.LookAt(target);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("Weapon"))
        {
            Destroy(gameObject);
        }
    }
    private void LevelSpeed()
    {
        MonsterSpeed *= Level;
    }
}
