using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScript : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemyScript = other.GetComponent<Enemy>();
            WorldHealthManager.Instance.TakeDamage(enemyScript.Damage);
            DestroyEnemy.Instance.ExplodeEnemy(other.gameObject);
        }
    }
}
