using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            StartCoroutine(other.GetComponent<DestroyEnemy>().SelfDestruct());
            //GameManager.Instance.DestroyEnemy(other.gameObject);
        }
    }
}
