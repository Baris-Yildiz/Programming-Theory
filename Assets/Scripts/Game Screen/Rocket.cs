using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Enemy
{
    void Start()
    {
        base.Start();
        StartCoroutine(IncreaseSpeed());
    }



    public Rocket()
    {
        Speed = 0.002f;
        Damage = 10;
        
    }

    IEnumerator IncreaseSpeed()
    {
        yield return new WaitForSeconds(0.6f);
        Speed += 0.001f;
        StartCoroutine(IncreaseSpeed());
    }

    private void OnEnable()
    {
        Speed = 0.002f;
        StartCoroutine(IncreaseSpeed());
    }

}
