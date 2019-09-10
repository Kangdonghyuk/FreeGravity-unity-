using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthGravity : MonoBehaviour
{
    public Transform sun;
    public Transform moon;

    Vector3 gravity;
    Vector3 gravity2;
    public float gravityPower;
    public float gravityPower2;
    float distance;

    void Start()
    {
        distance = 0f;
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, sun.position);

        if(distance >= gravityPower)
            distance = gravityPower;

        gravity.x = (transform.position.x - sun.position.x) /
            Mathf.Abs((distance / (distance - gravityPower)));
        gravity.y = (transform.position.y - sun.position.y) /
            Mathf.Abs((distance / (distance - gravityPower)));

        distance = Vector3.Distance(transform.position, moon.position);

        if(distance >= gravityPower2)
            distance = gravityPower2;

        gravity2.x = (transform.position.x - moon.position.x) /
            Mathf.Abs((distance / (distance - gravityPower2)));
        gravity2.y = (transform.position.y - moon.position.y) /
            Mathf.Abs((distance / (distance - gravityPower2)));

        transform.position = transform.position + (-gravity + -gravity2) * Time.deltaTime;
    }
}
