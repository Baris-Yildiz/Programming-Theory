using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    public GameObject explosion;
    public static DestroyEnemy Instance;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    public void ExplodeEnemy(GameObject enemy)
    {
        MusicManager.Instance.PlayAudio(Audio.EnemyExplosion);
        Instantiate(explosion, enemy.transform.position, Quaternion.identity);
        enemy.SetActive(false);
        GameManager.Instance.enemiesLeft--;
    }



}
