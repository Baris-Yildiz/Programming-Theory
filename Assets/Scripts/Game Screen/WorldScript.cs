using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScript : MonoBehaviour
{
    public float ammoDamage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemyScript = other.GetComponent<Enemy>();
            WorldHealthManager.Instance.TakeDamage(enemyScript.Damage);
            DestroyEnemy.Instance.ExplodeEnemy(other.gameObject);
        } else if (other.CompareTag("Bullet"))
        {
            if (ammoDamage == 0)
            {
                ammoDamage = FindObjectOfType<Alien>().Damage;
            }

            WorldHealthManager.Instance.TakeDamage(ammoDamage);
            other.gameObject.SetActive(false);
        }
    }
}
