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
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void ExplodeEnemy(GameObject enemy)
    {
        Instantiate(explosion, enemy.transform.position, Quaternion.identity);
        enemy.SetActive(false);
        GameManager.Instance.enemiesLeft--;
    }



}
