using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float CharacterSpeed;
    [SerializeField] private GameObject monsterPrefab;
    public static float CharacterHP;

    //--- terrain
    [SerializeField] private Terrain terrain;
    private float monsterRandomSpawnX;
    private float monsterRandomSpawnZ;
    private float SpawnX;
    private float SpawnY;
    private float SpawnZ;
    
    //--- 카메라 회전
    [SerializeField] private float rotSpeed = 350f;
    private Vector3 m_CharEuler = Vector3.zero;

    private float moveX;
    private float moveY;
    private float moveZ;

    [SerializeField] private float SpawnTime;
    private float WaitTime;
    private void Awake()
    {
        
    }
    private void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;

        SpawnX = (int)terrain.terrainData.size.x / 2;
        SpawnZ = (int)terrain.terrainData.size.z / 2;

        CharacterHP = 3f;
    }

    private void Update()
    {
        if(CharacterHP > 0)
        {
            Charactermove();
            CharacterRotate();
        }
        if(CharacterHP > 0 && Time.time >= 5f)
        {
            monsterRandomSpawnX = Random.Range(SpawnX * -1f, SpawnX);
            monsterRandomSpawnZ = Random.Range(SpawnZ * -1f, SpawnZ);
            SpawnY = terrain.SampleHeight(new Vector3(monsterRandomSpawnX, 0, monsterRandomSpawnZ)) + terrain.transform.position.y;
            Vector3 SpawnV = new Vector3(monsterRandomSpawnX, SpawnY, monsterRandomSpawnZ);
            SetSpawnMonster(SpawnV);
        }
    }
    private void SetSpawnMonster(Vector3 spawnV)
    {
        if(WaitTime > 0)
        {
            WaitTime -= Time.deltaTime;
        }
        else
        {
            Instantiate(monsterPrefab, spawnV, Quaternion.identity);
            WaitTime = SpawnTime;
        }
    }
    private void Charactermove()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.forward * moveZ + transform.right * moveX;
        transform.Translate(move * Time.deltaTime * CharacterSpeed, Space.World);
    }
    private void CharacterRotate()
    {
        if(Input.GetMouseButton(1))
        {
            m_CharEuler = transform.eulerAngles;

            m_CharEuler.y += Input.GetAxisRaw("Mouse X") * rotSpeed * Time.deltaTime;     // 왼 오른
            m_CharEuler.x -= Input.GetAxisRaw("Mouse Y") * rotSpeed * Time.deltaTime;     // 위 아래

            if (m_CharEuler.x >= 20f && m_CharEuler.x <= 180f)
                m_CharEuler.x = 20f;
            if (m_CharEuler.x <= 340f && m_CharEuler.x >= 180f)
                m_CharEuler.x = 340f;
            transform.eulerAngles = m_CharEuler;
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            CharacterHP -= 1f;
        }
    }
}