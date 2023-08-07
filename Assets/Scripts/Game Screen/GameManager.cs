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

    public enum SpawnDirection
    {
        Right,
        Left,
        Top,
        Bottom
    }

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
        int direction = Random.Range(0,4);
        Vector3 spawnPoint = Vector3.zero;

        switch ((SpawnDirection)direction)
        {
            case SpawnDirection.Bottom:
                spawnPoint = new Vector3(Random.Range(-5,5),-3,0);
                break;
            case SpawnDirection.Top:
                spawnPoint = new Vector3(Random.Range(-5, 5), 3, 0);
                break;
            case SpawnDirection.Right:
                spawnPoint = new Vector3(5, Random.Range(-3, 3), 0);
                break;
            case SpawnDirection.Left:
                spawnPoint = new Vector3(-5, Random.Range(-3,3), 0);
                break;
        }
        
        enemy.GetComponent<Rigidbody>().velocity = Vector3.zero;
        enemy.transform.position = spawnPoint;
        enemy.SetActive(true);
    }

}
