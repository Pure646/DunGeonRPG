using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] private List<ParticleObject> particleObject;
    [SerializeField] private GameObject Character;
    private List<float> PartyTime;              // ���� ��ƼŬ ���� �ð�
    private List<GameObject> activeParticles;   // Ȱ��ȭ�� ��ƼŬ ������Ʈ�� ����
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
    private void SecondTime(float partytime, int index)           // �ð�
    {
        if (partytime > 0f)
        {
            partytime -= Time.deltaTime;
            PartyTime[index] = partytime;
        }
        else if (partytime <= 0f) // �ð��� 0�� �����ϸ� ��ƼŬ ���߱�
        {
            // ��ƼŬ ���߱�
            ParticleSystem particleSystem = activeParticles[index].GetComponent<ParticleSystem>();
            particleSystem.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

            // ��ƼŬ ������Ʈ�� �ð� ����Ʈ���� �ش� �׸� ����
            Destroy(activeParticles[index]);    // ��ƼŬ ������Ʈ ����
            activeParticles.RemoveAt(index);    // ����Ʈ���� ��ƼŬ ������Ʈ ����
            PartyTime.RemoveAt(index);          // Ÿ�̸� ����Ʈ���� ����
        }
    }
}
