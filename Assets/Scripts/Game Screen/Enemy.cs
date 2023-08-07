using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject world;
    public GameObject World
    {
        get
        {
            return world;
        }
    }

    private Rigidbody enemyRb;

    private float speed;

    
    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }

    void Start()
    {
        world = GameObject.FindGameObjectWithTag("World");
        enemyRb = GetComponent<Rigidbody>();

        
        
    }


    void Update()
    {
        transform.LookAt(world.transform);
        enemyRb.AddForce(speed * transform.forward, ForceMode.Impulse);
    }

    private void OnMouseDown()
    {
        StartCoroutine(gameObject.GetComponent<DestroyEnemy>().SelfDestruct());
        //GameManager.Instance.DestroyEnemy(gameObject);
    }

    


    
}
