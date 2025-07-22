using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Particle_Name
{
    Air_Aura,
    Fire_Aura,
    Rock_Aura,
    Water_Aura,
    Elector_Aura,
}
public enum Particle_Type
{
    Air,
    Fire,
    Rock,
    Water,
    Electic,
}

[CreateAssetMenu(fileName = "Particle", menuName = "Particle_Object/Particle")]
public class ParticleObject : ScriptableObject
{
    public Particle_Name Name;
    public Particle_Type Type;
    public GameObject ParticlePrefab;

    public float Death_Time;            // 곧 사라지는 시간
}
