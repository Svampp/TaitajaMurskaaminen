using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    [SerializeField] GameObject WallPrefab;
    [SerializeField] Vector3 startPos;
    Vector3 spawnPos;
    [SerializeField] int wallAmount = 100;
    float wallDistace = 10f;


    private void Awake()
    {
        instance = this;
    }

    public void SpawnWalls()
    {
        spawnPos = startPos;

        for (int i = 0; i < wallAmount; i++)
        {
            Instantiate(WallPrefab, spawnPos, WallPrefab.transform.rotation);
            spawnPos.z += wallDistace;
        }
    }

    public void DestroyWalls()
    {
        GameObject[] destroyList = GameObject.FindGameObjectsWithTag("Wall");
        foreach (GameObject go in destroyList)
        {
            Destroy(go);
        }
    }
}
