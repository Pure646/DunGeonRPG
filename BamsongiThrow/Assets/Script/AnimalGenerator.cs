using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalGenearator : MonoBehaviour
{
    [SerializeField] private GameObject[] Animal;
    [SerializeField] private Terrain mapTerrain;

    private int AnimalSpawnX;
    private int AnimalSpawnZ;
    private int RandomX;
    private float AnimalY;
    private int RandomZ;

    private int nowStage = 0;
    private void Start()
    {
        if(mapTerrain != null)
        {
            AnimalSpawnX = (int)mapTerrain.terrainData.size.x / 2;
            AnimalSpawnZ = (int)mapTerrain.terrainData.size.z / 2;
        }
    }
    private void Update()
    {
        if(PlayerMovement.RoundStage > nowStage)
        {
            nowStage = PlayerMovement.RoundStage;       // 해당 라운드로 초기화;
            for (int i = 0; i < Animal.Length; i++)
            {
                RandomX = Random.Range(AnimalSpawnX * -1, AnimalSpawnX);
                RandomZ = Random.Range(AnimalSpawnZ * -1, AnimalSpawnZ);
                AnimalY = mapTerrain.SampleHeight(new Vector3(RandomX, 0, RandomZ)) + mapTerrain.transform.position.y;
                Vector3 AnimalSpawnVec = new Vector3(RandomX, AnimalY, RandomZ);
                Instantiate(Animal[i], AnimalSpawnVec, Quaternion.identity);
            }
        }
    }
}
