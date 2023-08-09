using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Enemy
{
    protected override void ResetProperties()
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
