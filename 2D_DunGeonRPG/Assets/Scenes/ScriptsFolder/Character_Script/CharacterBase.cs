using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace DunGeonRPG
{
    public class CharacterBase : MonoBehaviour
    {
        private Animator anime;
        private Rigidbody2D rigid;

        [SerializeField] private Vector2 transVec;
        [SerializeField] private float characterSpeed = 1f;
        public float AddSpeed = 0.1f;
        private float maxSpeed = 5f;

        [Header("Character Hit or Damage")]
        [SerializeField] float Damage = 0.25f;

        [Header("Character Health && Mana")]
        [Range(0, 100)]
        public int AddHealth;               // �߰� ü��       // �ʱⰪ : 0 (��Ʈ �Ѱ�)
        public int AddMana;                 // �߰� ����       // �ʱⰪ : 0 (��Ʈ �Ѱ�)
        public int NowHealth;               // �߰��� ü��
        public int NowMana;                 // �߰��� ����
        public float ChangeCurrentHealth;       // ü�� ����
        public float ChangeCurrentMana;         // ���� ����
        public float NowCurrentHealth;          // ���� ������ �ִ� ü��
        public float NowCurrentMana;            // ���� ������ �ִ� ����
        private void Awake()
        {
            rigid = GetComponent<Rigidbody2D>();
            anime = GetComponent<Animator>();
        }
        private void Start()
        {
            AddHealth = 1;          // �߰� ü��    (�⺻�� : 1)
            AddMana = 1;            // �߶� ����    (�⺻�� : 1)
            NowCurrentHealth = AddHealth;
            NowCurrentMana = AddMana;

            characterSpeed = 0.5f;
            maxSpeed = 200f;
        }
        private void Update()
        {
            CharacterAnime();
            
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Character_Damage();
            }
            if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                Character_AddHealth();
            }
        }
        private void FixedUpdate()
        {
            CharacterMovement();
        }
        private void CharacterMovement()            // Rigid.addForce �� �ٲ� ����
        {
            transVec = InputSystem.Instance.Move / 10;
            if(characterSpeed >= maxSpeed)
            {
                transform.Translate(transVec * maxSpeed, Space.Self);
            }
            else if(characterSpeed <= 0f)
            {
                characterSpeed = maxSpeed;
            }
            else
            {
                transform.Translate(transVec * characterSpeed, Space.Self);
            }
        }
        private void Character_Damage()
        {
            NowCurrentHealth -= Damage;
        }
        private void Character_AddHealth()
        {
            if(AddHealth > NowCurrentHealth)
            {
                NowCurrentHealth = AddHealth;       // �ִ�ü�� ���� ���� ü�� ���� �Ұ���
            }
            AddHealth = AddHealth + 1;
            NowCurrentHealth = AddHealth;
        }
        private void CharacterSpeed()                       // ĳ���� ���ǵ� �ο�
        {
            if(Input.GetKeyDown(KeyCode.Alpha9))
            {
                characterSpeed += AddSpeed;
            }
            if(Input.GetKeyDown(KeyCode.Alpha0))
            {
                characterSpeed -= AddSpeed;
            }
        }

        private void CharacterAnime()
        {
            anime.SetFloat("Magnitude", InputSystem.Instance.Move.magnitude);
            if(characterSpeed < maxSpeed)
            {
                anime.SetFloat("SpeedMotion", characterSpeed);
            }
            else
            {
                anime.SetFloat("SpeedMotion", maxSpeed);
            }
        }

        //private void GameOver()
        //{
        //    if(CurrentHealth <= 0)
        //    {
        //        Debug.Log("gameOver");
        //    }
        //}
    }
}
