using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldHealthManager : MonoBehaviour
{
    Slider healthBar;
    public static WorldHealthManager Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        healthBar = GetComponentInChildren<Slider>();
        healthBar.value = healthBar.maxValue;
    }


    public void TakeDamage(float damage)
    {
        healthBar.value -= damage;

        if (healthBar.value < 0)
        {
            //game over
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
