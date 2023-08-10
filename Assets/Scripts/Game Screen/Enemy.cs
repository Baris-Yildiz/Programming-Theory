using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    //ENCAPSULATION: getters and setters
    private GameObject world;
    public GameObject World
    {
        get
        {
            return world;
        }
    }


    private Rigidbody enemyRb;
    public Rigidbody EnemyRb
    {
        get
        {
            return enemyRb;
        }
    }


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


    private float damage;
    public float Damage
    {
        get
        {
            return damage;
        }
        set {
            damage = value;
        }
    }


    public void Start()
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
        DestroyEnemy.Instance.ExplodeEnemy(gameObject);
    }


    protected abstract void ResetProperties();  

}
