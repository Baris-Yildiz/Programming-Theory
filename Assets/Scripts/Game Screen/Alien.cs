using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : Enemy
{
    //INHERITANCE: Enemy types inherit the Enemy class
    protected override void ResetProperties()   //POLYMORPHISM: overrides parent method.
    {
        Speed = 0.001f * DifficultyManager.Instance.difficultyMultiplier;
        Damage = 10 * DifficultyManager.Instance.difficultyMultiplier;
    }

    private void Start()
    {
        base.Start();
        ResetProperties();
        StartCoroutine(StopAlien());
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
        MusicManager.Instance.PlayAudio(Audio.AlienShot);
        GameObject bullet = transform.GetChild(0).gameObject;
        bullet.SetActive(true);
        bullet.transform.position = gameObject.transform.position;
        yield return new WaitForSeconds(1);
        StartCoroutine(Shoot());
    }

    private void OnEnable()
    {
        ResetProperties();
        StartCoroutine(StopAlien());
    }

}
