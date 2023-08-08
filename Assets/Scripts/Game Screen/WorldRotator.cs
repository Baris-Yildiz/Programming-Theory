using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldRotator : MonoBehaviour
{
    float speed = 50;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(speed * Time.deltaTime * new Vector3(0.3f, 1, 0));
    }
}
