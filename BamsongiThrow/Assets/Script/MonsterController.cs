using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public GameObject Character;
    [SerializeField] private float MonsterSpeed;
    private CharacterController monsterCon;
    private void Start()
    {
        Character = GameObject.Find("Character");
        monsterCon = GetComponent<CharacterController>();
    }
    private void Update()
    {
        MonsterMove();
        MonsterRotate();
    }
    private void MonsterMove()
    {
        Vector3 direction = (Character.transform.position - transform.position).normalized;
        monsterCon.Move(direction * MonsterSpeed * Time.deltaTime);
    }
    private void MonsterRotate()
    {
        transform.LookAt(Character.transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(PlayerMovement.CharacterHP > 0)
        {
            if (other.CompareTag("Character"))
            {
                PlayerMovement.CharacterHP--;
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
