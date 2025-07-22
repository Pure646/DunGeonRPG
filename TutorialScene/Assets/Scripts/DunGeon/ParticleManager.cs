using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] private List<ParticleObject> particleObject;
    [SerializeField] private GameObject Character;
    private List<float> PartyTime;              // 각각 파티클 남은 시간
    private List<GameObject> activeParticles;   // 활성화된 파티클 오브젝트를 저장
    private void Start()
    {
        PartyTime = new List<float>();
        activeParticles = new List<GameObject>();
    }
    private void Update()
    {
        for (int i = 0; i < PartyTime.Count; i++) 
        {
            SecondTime(PartyTime[i], i);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            for (int i = 0; i < particleObject.Count; i++)
            {
                switch(particleObject[i].Name)
                {
                    case Particle_Name.Fire_Aura:
                        PartyTime.Add(particleObject[i].Death_Time);
                        SpawnParticle(particleObject[i]);
                        break;
                }
            }
        }
    }
    private void SpawnParticle(ParticleObject particle)
    {
        GameObject Fire_Object = Instantiate(particle.ParticlePrefab, transform.position, Quaternion.identity);
        Fire_Object.transform.SetParent(this.Character.transform, false);
        ParticleSystem Fire_Particle = Fire_Object.GetComponent<ParticleSystem>();

        Fire_Particle.Play();

        activeParticles.Add(Fire_Object);
    }
    private void SecondTime(float partytime, int index)           // 시간
    {
        if (partytime > 0f)
        {
            partytime -= Time.deltaTime;
            PartyTime[index] = partytime;
        }
        else if (partytime <= 0f) // 시간이 0에 도달하면 파티클 멈추기
        {
            // 파티클 멈추기
            ParticleSystem particleSystem = activeParticles[index].GetComponent<ParticleSystem>();
            particleSystem.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

            // 파티클 오브젝트와 시간 리스트에서 해당 항목 삭제
            Destroy(activeParticles[index]);    // 파티클 오브젝트 삭제
            activeParticles.RemoveAt(index);    // 리스트에서 파티클 오브젝트 제거
            PartyTime.RemoveAt(index);          // 타이머 리스트에서 제거
        }
    }
}
