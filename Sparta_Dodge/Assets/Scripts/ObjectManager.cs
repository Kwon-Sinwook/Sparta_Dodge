using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject bulletPlayerPrefab;
    public GameObject bulletEnemyPrefab;

    GameObject[] enemy;
    GameObject[] bulletPlayer;
    GameObject[] bulletEnemy;

    GameObject[] targetPool;

    private void Awake()
    {
        enemy = new GameObject[30];
        bulletPlayer = new GameObject[200];
        bulletEnemy = new GameObject[200];

        Generate();
    }

    void Generate()
    {
        for (int idx = 0; idx < enemy.Length; idx++)
        {
            enemy[idx] = Instantiate(enemyPrefab);
            enemy[idx].SetActive(false);
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
            case "Enemy":
                targetPool = enemy;
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
}
