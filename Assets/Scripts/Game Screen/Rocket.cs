using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Enemy
{
    //INHERITANCE: Enemy types inherit the Enemy class
    protected override void ResetProperties() //POLYMORPHISM: overrides parent method.
    {
        Speed = 0.002f * DifficultyManager.Instance.difficultyMultiplier;
        Damage = 10 * DifficultyManager.Instance.difficultyMultiplier / 2;
    }

    void Start()
    {
        ResetProperties();
        base.Start();
        StartCoroutine(IncreaseSpeed());
    }

    IEnumerator IncreaseSpeed()
    {
        yield return new WaitForSeconds(1f);
        Speed *= 2;
        StartCoroutine(IncreaseSpeed());
    }

    private void OnEnable()
    {
        ResetProperties();
        StartCoroutine(IncreaseSpeed());
    }

    
}
