using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject enemy0Prefab;
    public GameObject enemy1Prefab;
    public GameObject enemy2Prefab;

    public GameObject bulletPlayerPrefab;
    public GameObject bulletEnemyPrefab;

    GameObject[] enemy0;
    GameObject[] enemy1;
    GameObject[] enemy2;

    GameObject[] bulletPlayer;
    GameObject[] bulletEnemy;

    GameObject[] targetPool;

    private void Awake()
    {
        enemy0 = new GameObject[20];
        enemy1 = new GameObject[10];
        enemy2 = new GameObject[10];

        bulletPlayer = new GameObject[200];
        bulletEnemy = new GameObject[200];

        Generate();
    }

    void Generate()
    {
        for (int idx = 0; idx < enemy0.Length; idx++)
        {
            enemy0[idx] = Instantiate(enemy0Prefab);
            enemy0[idx].SetActive(false);
        }

        for (int idx = 0; idx < enemy1.Length; idx++)
        {
            enemy1[idx] = Instantiate(enemy1Prefab);
            enemy1[idx].SetActive(false);
        }

        for (int idx = 0; idx < enemy2.Length; idx++)
        {
            enemy2[idx] = Instantiate(enemy2Prefab);
            enemy2[idx].SetActive(false);
        }

        for (int idx = 0; idx < bulletPlayer.Length; idx++)
        {
            bulletPlayer[idx] = Instantiate(bulletPlayerPrefab);
            bulletPlayer[idx].SetActive(false);
        }

        for (int idx = 0; idx < bulletEnemy.Length; idx++)
        {
            bulletEnemy[idx] = Instantiate(bulletEnemyPrefab);
            bulletEnemy[idx].SetActive(false);
        }
            
    }

    public GameObject MakeObj(string type)
    {
        switch(type)
        {
            case "Enemy0":
                targetPool = enemy0;
                break;
            case "Enemy1":
                targetPool = enemy1;
                break;
            case "Enemy2":
                targetPool = enemy2;
                break;
            case "BulletPlayer":
                targetPool = bulletPlayer;
                break;
            case "BulletEnemy":
                targetPool = bulletEnemy;
                break;
        }
        for (int idx = 0; idx < targetPool.Length; idx++)
        {
            if (!targetPool[idx].activeSelf)
            {
                targetPool[idx].SetActive(true);
                return targetPool[idx];
            }
        }

        return null;

    }

    public GameObject[] GetPool(string type)
    {
        switch (type)
        {
            case "Enemy0":
                targetPool = enemy0;
                break;
            case "Enemy1":
                targetPool = enemy1;
                break;
            case "Enemy2":
                targetPool = enemy2;
                break;
            case "BulletPlayer":
                targetPool = bulletPlayer;
                break;
            case "BulletEnemy":
                targetPool = bulletEnemy;
                break;
        }

        return targetPool;
    }
}
