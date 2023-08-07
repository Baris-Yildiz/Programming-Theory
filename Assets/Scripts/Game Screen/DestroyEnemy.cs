using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    ParticleSystem explosion;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).CompareTag("Explosion"))
            {
                explosion = GetComponentInChildren<ParticleSystem>();
            }
        }
    }

    public IEnumerator SelfDestruct()
    {
        GameManager.Instance.enemiesLeft--;
        explosion.Play();
        yield return new WaitForSeconds(0.15f);
        gameObject.SetActive(false);
    }


}
