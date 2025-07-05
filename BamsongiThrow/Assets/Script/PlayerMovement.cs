using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static float CharacterHP = 3f;
    [SerializeField] private float CharacterSpeed;
    [SerializeField] private float RotateSpeed;
    [SerializeField] private GameObject monsterPrefab;

    private float moveX;
    private float moveY;
    private float moveZ;

    [SerializeField] private float SpawnTime;
    private float WaitTime;
    private void Awake()
    {

    }

    private void Update()
    {
        if(CharacterHP > 0)
        {
            Charactermove();
        }
        if(CharacterHP > 0 && Time.time >= 5f)
        {
            SetSpawnMonster();
        }
    }
    private void SetSpawnMonster()
    {
        if(WaitTime > 0)
        {
            WaitTime -= Time.deltaTime;
        }
        else
        {
            Instantiate(monsterPrefab);
            WaitTime = SpawnTime;
        }
    }
    private void Charactermove()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.forward * moveZ + transform.right * moveX;
        transform.Translate(move * Time.deltaTime * CharacterSpeed, Space.Self);
    }
    private void CharacterRotate()
    {
        if(Input.GetMouseButton(1))
        {
            // 마우스 초기값
            // 마우스 이동값
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            CharacterHP = -1f;
            //Debug.Log("Hit");
        }
    }
}