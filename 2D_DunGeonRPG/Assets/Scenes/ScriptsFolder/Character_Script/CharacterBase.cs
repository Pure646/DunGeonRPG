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
        public int AddHealth;               // 추가 체력       // 초기값 : 0 (하트 한개)
        public int AddMana;                 // 추가 마나       // 초기값 : 0 (하트 한개)
        public int NowHealth;               // 추가된 체력
        public int NowMana;                 // 추가된 마나
        public float ChangeCurrentHealth;       // 체력 변동
        public float ChangeCurrentMana;         // 마나 변동
        public float NowCurrentHealth;          // 현재 가지고 있는 체력
        public float NowCurrentMana;            // 현재 가지고 있는 마나
        private void Awake()
        {
            rigid = GetComponent<Rigidbody2D>();
            anime = GetComponent<Animator>();
        }
        private void Start()
        {
            AddHealth = 1;          // 추가 체력    (기본값 : 1)
            AddMana = 1;            // 추락 마나    (기본값 : 1)
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
        private void CharacterMovement()            // Rigid.addForce 로 바꿀 예정
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
                NowCurrentHealth = AddHealth;       // 최대체력 보다 높게 체력 설정 불가능
            }
            AddHealth = AddHealth + 1;
            NowCurrentHealth = AddHealth;
        }
        private void CharacterSpeed()                       // 캐릭터 스피드 부여
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
