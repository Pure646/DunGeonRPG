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

        private void Awake()
        {
            rigid = GetComponent<Rigidbody2D>();
            anime = GetComponent<Animator>();
        }
        private void Start()
        {
            characterSpeed = 0.5f;
            maxSpeed = 200f;
        }
        private void OnEnable()
        {
        }
        private void OnDisable()
        {
        }
        private void Update()
        {
            CharacterAnime();
            characterSpeed = characterSpeed + (Time.time * Time.deltaTime);
            
        }
        private void FixedUpdate()
        {
            CharacterMovement();
        }
        private void CharacterMovement()
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

        private void CharacteraRotation()                   // 캐릭터 회전
        {
            //if (InputSystem.Instance.Move.x < 0f)
            //{
            //    transform.rotation = Quaternion.Euler(0, -180f, 0);
            //}
            //else if (InputSystem.Instance.Move.x > 0f)
            //{
            //    transform.rotation = Quaternion.Euler(0, 0, 0);
            //}
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
    }

}
