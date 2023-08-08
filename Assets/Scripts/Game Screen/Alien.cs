using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : Enemy
{
    private void Start()
    {
        base.Start();
        StartCoroutine(StopAlien());
    }

    public Alien()
    {
        Speed = 0.001f;
        Damage = 1;
    }

    IEnumerator StopAlien()
    {
        yield return new WaitUntil(IsCloseEnoughToShoot);
        EnemyRb.velocity = Vector3.zero;
        Speed = 0;
        StartCoroutine(Shoot());
    }

    bool IsCloseEnoughToShoot()
    {
        return (World != null) && (transform.position - World.transform.position).magnitude < 2;
        
    }
   
    IEnumerator Shoot()
    {
        GameObject bullet = transform.GetChild(0).gameObject;
        bullet.SetActive(true);
        bullet.transform.position = gameObject.transform.position;
        yield return new WaitForSeconds(1);
        StartCoroutine(Shoot());
    }

    private void OnEnable()
    {
        Speed = 0.001f;
        StartCoroutine(StopAlien());
    }

}
