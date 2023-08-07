using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int enemiesToSpawn = 1;
    public static GameManager Instance;

    public int enemiesLeft = 1;

    public GameObject[] enemies;
    private GameObject enemyContainer;

    void Start()
    {
        enemyContainer = GameObject.FindWithTag("Enemies");

        if (Instance == null)
        {
            Instance = this;
        }

        StartCoroutine(SpawnEnemyWave());
    }

    void Update()
    {
        
    }

    public IEnumerator SpawnEnemyWave()
    {
        yield return new WaitForSeconds(3);

        enemiesLeft = enemiesToSpawn;

        for (int i = 0; i < enemiesToSpawn - enemyContainer.transform.childCount; i++)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], enemyContainer.transform).SetActive(false);
        }

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            SpawnEnemy(enemyContainer.transform.GetChild(i).gameObject);
            yield return new WaitForSeconds(Random.Range(1, 2));
        }

        yield return new WaitUntil(AllEnemiesDefeated);
        enemiesToSpawn++;

        StartCoroutine(SpawnEnemyWave());
    }

    bool AllEnemiesDefeated()
    {
        return enemiesLeft == 0;
    }

    void SpawnEnemy(GameObject enemy)
    {
        Vector3 spawnPoint = Vector3.one;
        enemy.GetComponent<Rigidbody>().velocity = Vector3.zero;
        enemy.transform.position = spawnPoint;
        enemy.SetActive(true);
    }

    public void DestroyEnemy(GameObject enemy)
    {
        enemiesLeft--;
        enemy.SetActive(false);
    }

}
