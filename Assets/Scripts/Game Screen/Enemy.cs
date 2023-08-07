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

    // Start is called before the first frame update
    void Start()
    {
        world = GameObject.FindGameObjectWithTag("World");
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRb.AddForce(Time.deltaTime * speed * (world.transform.position - transform.position), ForceMode.Impulse);
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
